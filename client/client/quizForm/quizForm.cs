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
using System.Xml.Linq;

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
        public int playerNum = 0;
        public int playerScore = 0;
        public string yourAnswer = ""; //이번에 입력한 정답.
        public bool isAnswerCorrect = false;

        Form1 parentForm;

        class UserInfo
        {
            public string userNickname;
            public string userImage;
            public UserInfo(string nickname, string image)
            {
                userNickname = nickname;
                userImage = image;
            }
        }

        UserInfo userInfo;

        public quizForm(TcpClient client, NetworkStream stream, int playerNum, string nickname, string user64image, Form1 parentForm)
        {
            InitializeComponent();

            SoundManager.PlaySoundLoop(@"..\..\Resources\quiz.wav");

            this.client = client;
            this.stream = stream;
            this.playerNum = playerNum;
            this.parentForm = parentForm;

            reader = new StreamReader(this.stream);
            writer = new StreamWriter(this.stream) { AutoFlush = true };

            userInfo = new UserInfo(nickname, user64image);
            SendUserData(userInfo.userNickname, userInfo.userImage);

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

                            List<PlayerResult> ranking = new List<PlayerResult>();
                            Label[] labels = { pname1, pname2, pname3, pname4 };
                            int rank = 1;
                            foreach (var kvp in scoreMap.OrderByDescending(kvp => kvp.Value))
                            {
                                Console.WriteLine($"Player {kvp.Key + 1}: {kvp.Value}점");
                                ranking.Add(new PlayerResult(rank++, kvp.Key + 1, labels[kvp.Key].Text, kvp.Value));
                            }

                            Invoke(new Action(() =>
                            {
                                try
                                {
                                    var resultForm = new quizResult(ranking, client, parentForm, playerNum);
                                    resultForm.Show();
                                    SoundManager.StopSound();
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
                    else if (msg.StartsWith("ALL_USERS:"))
                    {
                        UserInfo[] users = ReceiveAllClientsData(msg);

                        Invoke(new Action(() =>
                        {
                            PictureBox[] playerPics = { playerPic1, playerPic2, playerPic3, playerPic4 };
                            Label[] labels = { pname1, pname2, pname3, pname4 };

                            for (int i = 0; i < users.Length; i++)
                            {
                                if (users[i] != null)
                                {
                                    labels[i].Text = (i + 1) + "P " + users[i].userNickname;

                                    try
                                    {
                                        byte[] imgBytes = Convert.FromBase64String(users[i].userImage);
                                        using (MemoryStream ms = new MemoryStream(imgBytes))
                                        {
                                            playerPics[i].Image = Image.FromStream(ms);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("이미지 변환 오류: " + ex.Message);
                                    }
                                }
                            }
                        }));
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

        private void SendUserData(string nickname, string imageBase64)
        {
            if (writer == null)
            {
                MessageBox.Show("writer가 null입니다 (SendUserData)");
                return;
            }

            string msg = $"USER_INFO:NICKNAME={nickname};IMAGE={imageBase64}";
            writer.WriteLine(msg);
        }

        private UserInfo[] ReceiveAllClientsData(string message)
        {
            UserInfo[] users = new UserInfo[4];

            // 메시지 예시: SEND_ALL_USERS:0=Alice;base64img1|1=Bob;base64img2|2=Carol;base64img3|3=Dan;base64img4
            string raw = message.Substring("ALL_USERS:".Length); // 앞부분 제거
            string[] entries = raw.Split('|');

            foreach (string entry in entries)
            {
                string[] kv = entry.Split('=');
                if (kv.Length != 2) continue;

                int idx = int.Parse(kv[0]);
                string[] infoParts = kv[1].Split(';');

                if (infoParts.Length == 2)
                {
                    string nickname = infoParts[0];
                    string imageBase64 = infoParts[1];

                    users[idx] = new UserInfo(nickname, imageBase64);
                }
            }

            return users;
        }

        private void quizForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SoundManager.StopSound();
        }
    }
}
