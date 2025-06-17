using client.classes;
using client.classes.NetworkManager;
using client.menuControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.quizForm
{
    public partial class quizForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;

        private StreamReader reader;
        private StreamWriter writer;

        //들어온 순서대로 1p, 2p, 3p, 4p가 정해짐
        //화면을 보고 있는 플레이어가 몇p인지 나타내는 변수 필요
        //ready화면에서 받아와야할듯?
        public int playerNum = 0; //배열 인덱스 생각해서, 실제 번호 -1 로 할까
        public int playerScore = 0;
        public string yourAnswer = ""; //이번에 입력한 정답.
        public bool isAnswerCorrect = false;

        List<(string Nickname, byte[] Image)> users = new List<(string Nickname, byte[] Image)>();

        public quizForm(TcpClient client, NetworkStream stream, int playerNum)
        {
            InitializeComponent();

            this.client = client;
            this.stream = stream;
            this.playerNum = playerNum;

            SendUserData(stream, userInfo.userNickname, userInfo.userImage);
            this.Load += async (s, e) => await quizForm_Load(s, e);

            reader = new StreamReader(this.stream);
            writer = new StreamWriter(this.stream) { AutoFlush = true };

            PictureBox[] playerPics = { playerPic1, playerPic2, playerPic3, playerPic4 };
            Label[] playerScores = { playerScore1, playerScore2, playerScore3, playerScore4 };
            Label[] playerPlus = { player1Plus, player2Plus, player3Plus, player4Plus };
            Label[] labels = { label1, label2, label3, label4 };

            PictureBox[] speechBubbles = { pic_sb1, pic_sb2, pic_sb3, pic_sb4 };
            Label[] playerAnswers = { playerAnswer1, playerAnswer2, playerAnswer3, playerAnswer4 };

            for (int i = 0; i < 4; i++)
            {
                playerPlus[i].Visible = false;
                playerAnswers[i].Visible = false;
                speechBubbles[i].Visible = false;
            }

            playerScores[playerNum].Text = playerScore.ToString();
            answerReadyTimer.Enabled = true;

            labels[playerNum].ForeColor = Color.Blue;
            playerScores[playerNum].ForeColor = Color.Blue;

            lbl_timer.Enabled = true;
            // 메시지 수신 스레드 시작
            Thread receiveThread = new Thread(ReceiveMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }


        private void ReceiveMessages()
        {
            Label[] playerScores = { playerScore1, playerScore2, playerScore3, playerScore4 };
            Label[] playerPlus = { player1Plus, player2Plus, player3Plus, player4Plus };

            PictureBox[] speechBubbles = { pic_sb1, pic_sb2, pic_sb3, pic_sb4 };
            Label[] playerAnswers = { playerAnswer1, playerAnswer2, playerAnswer3, playerAnswer4 };

            while (true)
            {
                try
                {
                    string msg = reader.ReadLine();
                    if (msg == null) break;

                    if (msg.StartsWith("QUIZ:"))
                    {
                        for (int i = 0; i < playerAnswers.Length; i++)
                        {
                            playerAnswers[i].Text = "(미응답)";
                        }
                        yourAnswer = "";
                        string question = msg.Substring(5);
                        Invoke(new Action(() =>
                        {
                            txt_question.Text = question;
                            txt_answer.Text = "";
                            txt_answer.Enabled = true;
                            lbl_timer.Text = "10";
                            timer_count = 0;
                            answerReadyTimer.Enabled = true;

                            Invoke(new Action(() =>
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    playerPlus[i].Visible = false;
                                    speechBubbles[i].Visible = false;
                                    playerAnswers[i].Visible = false;
                                    playerAnswers[i].ForeColor = Color.Black;
                                }
                            }));
                        }));
                    }
                    else if (msg.StartsWith("RESULT:"))
                    {
                        string result = msg.Substring(7);
                        isAnswerCorrect = result == "CORRECT";
                        Invoke(new Action(() =>
                        {
                            if (isAnswerCorrect)
                            {
                                playerAnswers[playerNum].ForeColor = Color.Blue;
                                playerPlus[playerNum].Visible = true;
                                playerScore += 10;
                                playerScores[playerNum].Text = playerScore.ToString();
                            }
                            else
                            {
                                playerAnswers[playerNum].ForeColor = Color.Red;
                            }
                        }));
                    }
                    else if (msg.StartsWith("SCORES:"))
                    {
                        // 예: SCORES:0=10;1=0;2=20;3=0
                        string[] entries = msg.Substring(7).Split(';');
                        foreach (string entry in entries)
                        {
                            string[] kv = entry.Split('=');
                            int idx = int.Parse(kv[0]);
                            int score = int.Parse(kv[1]);
                            Invoke(new Action(() => playerScores[idx].Text = score.ToString()));
                        }
                    }
                    else if (msg.StartsWith("COUNTDOWN:"))
                    {
                        string count = msg.Substring(10).Trim();
                        Invoke(new Action(() =>
                        {
                            txt_question.Text = count;
                            txt_question.Visible = true;
                        }));
                    }
                    else if (msg.StartsWith("ANSWERS:"))
                    {
                        string raw = msg.Substring(8);
                        string[] entries = raw.Split(';');
                        Invoke(new Action(() =>
                        {
                            for (int i = 0; i < entries.Length; i++)
                            {
                                string[] parts = entries[i].Split('=');
                                int idx = int.Parse(parts[0]);
                                string ans = parts[1];

                                playerAnswers[idx].Text = string.IsNullOrWhiteSpace(ans) ? "(미응답)" : ans;
                                playerAnswers[idx].Visible = false; // 일단 숨겨둠
                                speechBubbles[idx].Visible = false;
                            }
                        }));
                    }
                    else if (msg.StartsWith("CORRECTS:"))
                    {
                        string raw = msg.Substring(9);
                        string[] entries = raw.Split(';');

                        Invoke(new Action(() =>
                        {
                            for (int i = 0; i < entries.Length; i++)
                            {
                                int idx = int.Parse(entries[i].Split('=')[0]);
                                bool isCorrect = entries[i].Split('=')[1] == "1";

                                speechBubbles[idx].Visible = true;
                                playerAnswers[idx].Visible = true;
                                playerAnswers[idx].ForeColor = isCorrect ? Color.Blue : Color.Red;
                                playerPlus[idx].Visible = isCorrect ? true : false;
                            }
                        }));
                    }
                    else if (msg.StartsWith("FINAL_SCORES:"))
                    {
                        try
                        {
                            string raw = msg.Substring(13); // FINAL_SCORES: 다음 부분

                            // 안전한 파싱
                            Dictionary<int, int> scoreMap = new Dictionary<int, int>();
                            foreach (var entry in raw.Split(';'))
                            {
                                var parts = entry.Split('=');
                                if (parts.Length == 2 &&
                                    !string.IsNullOrWhiteSpace(parts[0]) &&
                                    int.TryParse(parts[0], out int key) &&
                                    int.TryParse(parts[1], out int value))
                                {
                                    scoreMap[key] = value;
                                }
                                else
                                {
                                    MessageBox.Show("파싱 실패한 항목: " + entry);
                                }
                            }

                            foreach (var kvp in scoreMap)
                            {
                                Console.WriteLine($"Player {kvp.Key + 1}: {kvp.Value}점");
                            }

                            // 순위 계산
                            var ranking = scoreMap
                                .OrderByDescending(kvp => kvp.Value)
                                .Select((kvp, idx) => new PlayerResult(idx + 1, kvp.Key + 1, kvp.Value))
                                .ToList();

                            Invoke(new Action(() =>
                            {
                                try
                                {
                                    var resultForm = new quizResult(ranking, client);
                                    resultForm.Show();
                                    this.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("결과창 오류 (내부): " + ex.Message);
                                }
                            }));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("결과창 오류 (외부): " + ex.Message);
                        }
                    }

                }
                catch
                {
                    break;
                }
            }
        }

        private void SendAnswer(string answer)
        {
            if (writer == null)
            {
                MessageBox.Show("writer가 null입니다");
            }

            writer.WriteLine("ANSWER:" + answer);
        }

        private void txt_answer_KeyDown(object sender, KeyEventArgs e)
        {
            Label[] playerAnswers = { playerAnswer1, playerAnswer2, playerAnswer3, playerAnswer4 };
            PictureBox[] speechBubbles = { pic_sb1, pic_sb2, pic_sb3, pic_sb4 };
            if (e.KeyCode == Keys.Enter && txt_answer.Text != "")
            {
                yourAnswer = txt_answer.Text;
                playerAnswers[playerNum].Text = yourAnswer;
                playerAnswers[playerNum].Visible = true;
                speechBubbles[playerNum].Visible = true;
                txt_answer.Enabled = false;

                SendAnswer(yourAnswer); // 바로 전송
            }
        }

        public int timer_count = 0;
        private void answerReadyTimer_Tick(object sender, EventArgs e)
        {
            PictureBox[] speechBubbles = { pic_sb1, pic_sb2, pic_sb3, pic_sb4 };
            Label[] playerAnswers = { playerAnswer1, playerAnswer2, playerAnswer3, playerAnswer4 };
            lbl_timer.Text = (9 - timer_count).ToString();
            timer_count++;

            if (timer_count == 10)
            {
                answerReadyTimer.Enabled = false;
                txt_answer.Enabled = false;

                if (string.IsNullOrWhiteSpace(yourAnswer))
                {
                    yourAnswer = null;
                    playerAnswers[playerNum].Text = "(미응답)";
                    playerAnswers[playerNum].Visible = true;
                    speechBubbles[playerNum].Visible = true;
                    SendAnswer("(미응답)"); // 빈 정답 전송
                }

            }
        }

        void SendUserData(NetworkStream stream, string nickname, byte[] profileImage)
        {
            using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(nickname.Length);
                writer.Write(nickname);
                writer.Write(profileImage.Length);
                writer.Write(profileImage);
            }
        }

        List<(string Nickname, byte[] Image)> ReceiveAllClientsData(NetworkStream stream)
        {
            List<(string, byte[])> result = new List<(string, byte[])>();
            using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, true))
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    int nameLen = reader.ReadInt32();
                    string nickname = new string(reader.ReadChars(nameLen));

                    int imageLen = reader.ReadInt32();
                    byte[] image = reader.ReadBytes(imageLen);

                    result.Add((nickname, image));
                }
            }
            return result;
        }

        class UserInfo
        {
            public string userNickname;
            public byte[] userImage;
        }

        UserInfo userInfo = new UserInfo();
        //5000번 포트에서 데이터를 가져오는 작업. 이후 게임이 시작되면 그쪽으로 보낼듯
        //애초에 게임폼에서 가져오는게 나으려나???
        //5000번에서 가져옴 -> 8888로 보냄 -> 8888이 네개를 모아서 클라이언트 전부에게 보냄

        public async Task LoadUserInfo(string currentUserId)
        {
            if (string.IsNullOrEmpty(currentUserId))
                return;

            try
            {
                string request = $"LOAD_STATS:{currentUserId}";
                await NetworkManager.Instance.SendMessageAsync(request);

                // 1. 헤더(통계 데이터) 수신 (끝에 ::END_HEADER:: 포함)
                string header = await NetworkManager.Instance.ReceiveHeaderAsync();
                //Console.WriteLine($"서버에서 받은 헤더: '{header}'");

                if (string.IsNullOrEmpty(header) || header == "STATS_LOAD_FAIL")
                {
                    MessageBox.Show("유저 통계 정보를 불러오지 못했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] stats = header.Split('|');
                if (stats.Length < 10)
                {
                    MessageBox.Show("유효하지 않은 데이터 형식입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // UI에 데이터 설정
                userInfo.userNickname = stats[0];

                // 2. 이미지 데이터 수신 (Base64 문자열, 끝에 ::END::)
                string base64Image = await NetworkManager.Instance.ReceiveFullMessageUntilEndAsync("");
                //Console.WriteLine($"서버에서 받은 이미지 Base64 길이: {base64Image?.Length ?? 0}");

                if (!string.IsNullOrWhiteSpace(base64Image))
                {
                    try
                    {
                        byte[] imgBytes = Convert.FromBase64String(base64Image);
                        userInfo.userImage = imgBytes;
                    }
                    catch (FormatException ex)
                    {
                        //Console.WriteLine($"[프로필 이미지 오류] {ex.Message}");
                        //MessageBox.Show("프로필 이미지 데이터가 손상되었습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    userInfo.userImage = null;
                }

                //Console.WriteLine("[클라이언트] 유저 통계 및 프로필 사진 로드 완료");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"[클라이언트] 유저 통계 로드 중 오류 발생: {ex}");
                //MessageBox.Show("유저 통계 로드 중 오류가 발생했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task quizForm_Load(object sender, EventArgs e)
        {
            await LoadUserInfo(UserSession.Instance.UserId);
            //SendServerUserInfo();

            // 모든 클라이언트 정보 수신
            users = ReceiveAllClientsData(stream);

            // 이후 UI 반영
            //label1.Text = users[playerNum].userNickname;
            //pictureBox1.Image = ByteArrayToImage(users[playerNum].userImage);
        }
    }
}
