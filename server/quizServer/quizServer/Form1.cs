using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace quizServer
{
    public partial class Form1 : Form
    {
        class PlayerInfo
        {
            public int player_number;
            public int player_score;
            public string player_answer;
            public bool is_correct;

            public PlayerInfo(int player_number, int player_score, string player_answer, bool is_correct)
            {
                this.player_number = player_number;
                this.player_score = player_score;
                this.player_answer = player_answer;
                this.is_correct = is_correct;
            }
        }

        class UserInfo
        {
            public string userNickname { get; set; }
            public string userImage { get; set; }
        }

        UserInfo[] users = new UserInfo[4]; //여기에 클라이언트에서 받은 info 저장!

        class GameRoom
        {
            public bool GameStarted;

            public int RoomId;
            public List<TcpClient> Players = new List<TcpClient>();
            public Dictionary<int, TcpClient> playerSockets = new Dictionary<int, TcpClient>(); // playerNum -> TcpClient
            public Dictionary<int, int> playerScores = new Dictionary<int, int>(); // playerNum -> score
            public Dictionary<int, string> playerAnswers = new Dictionary<int, string>(); // playerNum -> answer
            public Dictionary<int, UserInfo> userInfos = new Dictionary<int, UserInfo>(); // playerNum -> userInfo

            public List<(string Question, string Answer)> Questions = new List<(string Question, string Answer)>()
            {
                ("O/X: C언어에서 int 변수는 음수를 저장할 수 있다.", "O"),
                ("C언어에서 문자열의 끝을 나타내는 문자 상수는?", "\\0"),
                ("O/X: & 연산자는 변수의 주소를 구하는 데 사용된다.", "O"),
            };

            /*("O/X: C언어에서 int 변수는 음수를 저장할 수 있다.", "O"),
                ("scanf 함수에서 정수형 값을 입력받을 때 사용하는 서식 지정자는?", "%d"),
                ("O/X: C언어에서 배열의 크기는 실행 중에 변경할 수 있다.", "X"),
                ("char str[6] = \"hello\";에서 str 배열의 크기는?", "6"),
                ("포인터를 선언할 때 사용하는 기호는?", "*"),
                ("O/X: C언어에서 main() 함수는 프로그램의 시작점이다.", "O"),
                ("for 반복문에서 조건식이 거짓이면 반복문은 몇 번 실행되는가?", "0"),
                ("C언어에서 문자열의 끝을 나타내는 문자 상수는?", "\\0"),
                ("O/X: & 연산자는 변수의 주소를 구하는 데 사용된다.", "O"),
                ("int a = 5, b = 2; printf(\"%d\", a / b);의 출력값은?", "2")*/

            public int CurrentQuestionIndex = 0;
        }

        TcpListener server;

        Dictionary<int, GameRoom> rooms = new Dictionary<int, GameRoom>();
        int nextRoomId = 1;
        //List<GameRoom> rooms = new List<GameRoom>();
        //int nextRoomId = 1;

        List<PlayerInfo> playerInfos = new List<PlayerInfo>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(StartServer);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void StartServer()
        {
            server = new TcpListener(IPAddress.Any, 8888);
            server.Start();
            AddLog("서버 시작됨");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                GameRoom room = null;
                lock (rooms)
                {
                    room = rooms.Values.FirstOrDefault(r => r.Players.Count < 4 && !r.GameStarted);
                    if (room == null)
                    {
                        room = new GameRoom { RoomId = nextRoomId++ };
                        rooms[room.RoomId] = room;
                    }

                    room.Players.Add(client);
                    int playerNumber = room.Players.Count - 1;
                    room.playerSockets[playerNumber] = client;
                    room.playerScores[playerNumber] = 0;

                    var writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
                    writer.WriteLine($"ROOM:{room.RoomId};PLAYER:{playerNumber}");

                    AddLog($"클라이언트 접속: {room.RoomId}번 방; {playerNumber}");

                    foreach (var p in room.Players)
                    {
                        var w = new StreamWriter(p.GetStream()) { AutoFlush = true };
                        w.WriteLine($"UPDATE_PANEL:{room.Players.Count}");
                    }

                    Thread clientThread = new Thread(() => HandleClient(client, room.RoomId, playerNumber));
                    clientThread.IsBackground = true;
                    clientThread.Start();

                    // 게임 시작 조건 체크
                    lock (room)
                    {
                        if (!room.GameStarted && room.Players.Count == 4)
                        {
                            room.GameStarted = true;

                            foreach (var p in room.Players)
                            {
                                var w = new StreamWriter(p.GetStream()) { AutoFlush = true };
                                w.WriteLine("START");
                            }

                            new Thread(() =>
                            {
                                for (int i = 3; i >= 1; i--)
                                {
                                    foreach (var p in room.Players)
                                    {
                                        var w = new StreamWriter(p.GetStream()) { AutoFlush = true };
                                        w.WriteLine("COUNTDOWN:" + i);
                                    }
                                    Thread.Sleep(1000);
                                }

                                SendNextQuestion(room);
                            }).Start();
                        }
                    }
                }
            }

            //StartZombieCleaner();
        }

        private void HandleClient(TcpClient client, int roomId, int playerNumber)
        {
            AddLog($"[서버] HandleClient 실행 - 방 {roomId}");

            if (!rooms.ContainsKey(roomId)) return;
            GameRoom room = rooms[roomId];

            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };

            //ReceiveFromClient(stream);

            try
            {
                while (true)
                {
                    string message = reader.ReadLine();
                    if (message == null) break;

                    if (message == "LEAVE")
                        break;

                    if (message.StartsWith("ANSWER:"))
                    {
                        string answer = message.Substring(7).Trim();

                        lock (room)
                        {
                            room.playerAnswers[playerNumber] = answer;

                            // 모든 플레이어가 답변을 제출했는지 확인
                            if (room.playerAnswers.Count == room.playerSockets.Count)
                            {
                                var (q, correctAnswer) = room.Questions[room.CurrentQuestionIndex];

                                // 중복 채점 방지를 위해 Thread로 분리 (UI deadlock 방지)
                                new Thread(() =>
                                {
                                    JudgeAnswers(room, correctAnswer);
                                }).Start();
                            }
                        }
                    }
                    if (message.StartsWith("USER_INFO:"))
                    {
                        // 예시: USER_INFO:NICKNAME=철수;IMAGE=dog.png
                        string data = message.Substring("USER_INFO:".Length);
                        string[] parts = data.Split(';');
                        string nickname = parts[0].Split('=')[1];
                        string image = parts[1].Split('=')[1];

                        var userInfo = new UserInfo { userNickname = nickname, userImage = image };

                        lock (room)
                        {
                            room.userInfos[playerNumber] = userInfo;

                            // 모든 유저 정보가 들어오면 브로드캐스트
                            if (room.userInfos.Count == 4 && room.userInfos.Keys.All(k => room.userInfos[k] != null))
                            {
                                BroadcastUserInfos(room);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog($"클라이언트 오류: {ex.Message}");
            }
            finally
            {
                client.Close();
                AddLog($"클라이언트 연결 종료: 방 {roomId}");

                lock (rooms)
                {
                    if (rooms.ContainsKey(roomId))
                    {
                        GameRoom r = rooms[roomId];
                        r.Players.Remove(client);
                        r.playerSockets.Remove(playerNumber);
                        r.playerScores.Remove(playerNumber);
                        r.playerAnswers.Remove(playerNumber);

                        BroadcastRoomStatus(r);

                        if (r.Players.Count == 0)
                        {
                            rooms.Remove(roomId);
                            AddLog($"빈 방 {roomId} 제거됨");
                        }
                    }
                }
            }
        }


        void BroadcastRoomStatus(GameRoom room)
        {
            string msg = $"UPDATE_PANEL:{room.Players.Count}";
            foreach (var p in room.Players)
            {
                var writer = new StreamWriter(p.GetStream()) { AutoFlush = true };
                writer.WriteLine(msg);
            }
        }

        private void JudgeAnswers(GameRoom room, string correctAnswer)
        {
            foreach (var kvp in room.playerSockets)
            {
                int playerNum = kvp.Key;
                TcpClient client = kvp.Value;
                string answer = room.playerAnswers.ContainsKey(playerNum) ? room.playerAnswers[playerNum] : "";

                bool isCorrect = answer.Trim().ToLower() == correctAnswer.ToLower();

                if (!room.playerScores.ContainsKey(playerNum))
                    room.playerScores[playerNum] = 0;

                if (isCorrect)
                    room.playerScores[playerNum] += 10;

                var writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
                writer.WriteLine("RESULT:" + (isCorrect ? "CORRECT" : "WRONG"));
            }

            // 결과 메시지 준비
            string answerMessage = "ANSWERS:" + string.Join(";", room.playerAnswers
                .Select(kvp => $"{kvp.Key}={kvp.Value}"));

            string correctMessage = "CORRECTS:" + string.Join(";", room.playerSockets
                .Select(kvp =>
                {
                    int playerNum = kvp.Key;
                    string ans = room.playerAnswers.ContainsKey(playerNum) ? room.playerAnswers[playerNum] : "(미응답)";
                    bool correct = ans.Trim().ToLower() == correctAnswer.ToLower();
                    return $"{playerNum}={(correct ? 1 : 0)}";
                }));

            AddLog("correctMessage 생성");

            // 모든 클라이언트에게 결과 전송
            foreach (var client in room.Players)
            {
                var writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
                writer.WriteLine(answerMessage);
                writer.WriteLine(correctMessage);
            }

            AddLog("결과 전송");

            // 점수 일괄 전송
            string scoreMessage = "SCORES:" + string.Join(";", room.playerScores.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            foreach (var p in room.Players)
            {
                var writer = new StreamWriter(p.GetStream()) { AutoFlush = true };
                writer.WriteLine(scoreMessage);
            }
            AddLog("점수 전송");

            // 3초 텀 후 다음 문제 전송
            new Thread(() =>
            {
                Thread.Sleep(3000); // 3초 대기
                room.CurrentQuestionIndex++;
                SendNextQuestion(room);
            }).Start();
        }

        private void SendNextQuestion(GameRoom room)
        {
            room.playerAnswers.Clear();

            if (room.CurrentQuestionIndex >= room.Questions.Count)
            {
                string finalScore = "FINAL_SCORES:" + string.Join(";", room.playerScores.Select(kvp => $"{kvp.Key}={kvp.Value}"));

                foreach (var p in room.Players)
                {
                    var writer = new StreamWriter(p.GetStream()) { AutoFlush = true };
                    writer.WriteLine("QUIZ_END:게임이 종료되었습니다.");
                    writer.WriteLine(finalScore);
                    AddLog("QUIZ_END:게임이 종료되었습니다.");
                    AddLog(finalScore);
                }
                return;
            }

            var (question, answer) = room.Questions[room.CurrentQuestionIndex];
            room.playerAnswers.Clear();

            foreach (var entry in room.playerSockets)
            {
                var writer = new StreamWriter(entry.Value.GetStream()) { AutoFlush = true };
                writer.WriteLine("QUIZ:" + question);
            }
        }

        private void AddLog(string msg)
        {
            if (lstLog.InvokeRequired)
                lstLog.Invoke(new Action(() => lstLog.Items.Add(msg)));
            else
                lstLog.Items.Add(msg);
        }

        private void StartZombieCleaner()
        {
            Thread cleanerThread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(5000);

                    lock (rooms)
                    {
                        var toRemove = rooms
                            .Where(r => r.Value.Players.Count == 0 && r.Value.GameStarted)
                            .Select(r => r.Key)
                            .ToList();

                        foreach (int id in toRemove)
                        {
                            rooms.Remove(id);
                            AddLog($"좀비 방 {id} 제거됨");
                        }
                    }
                }
            });
            cleanerThread.IsBackground = true;
            cleanerThread.Start();
        }

        private void BroadcastUserInfos(GameRoom room)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                if (room.userInfos.TryGetValue(i, out UserInfo user))
                {
                    sb.Append($"{i}={user.userNickname};{user.userImage}|");
                }
            }

            // 맨 마지막 구분자 제거
            if (sb.Length > 0)
                sb.Length--;

            string message = "ALL_USERS:" + sb.ToString();

            foreach (var client in room.Players)
            {
                var writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
                writer.WriteLine(message);
            }

            AddLog("모든 유저 정보 전송 완료");
        }
    }
}
