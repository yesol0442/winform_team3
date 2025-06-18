using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Diagnostics;
using client.classes.NetworkManager;

namespace client.quizForm
{
    public partial class quizReady : Form
    {
        TcpClient client;
        NetworkStream stream;

        Form1 parentForm;

        int playerNum;
        private string userNickname, user64Image;

        public quizReady(string nickname, string user64image, Form1 parentForm)
        {
            InitializeComponent();
            client = new TcpClient();
            client.Connect("127.0.0.1", 8888); // 서버 IP 주소
            stream = client.GetStream();

            userNickname = nickname;
            user64Image = user64image;

            Thread receiveThread = new Thread(ReceiveData);
            receiveThread.IsBackground = true;
            receiveThread.Start();
            this.parentForm = parentForm;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
                writer.WriteLine("LEAVE");
            }
            catch { }

            this.Close();
            stream.Close();
            client.Close();
        }

        private void ReceiveData()
        {
            StreamReader reader = new StreamReader(stream);

            while (true)
            {
                try
                {
                    string serverMessage = reader.ReadLine();
                    if (serverMessage == null) break;

                    if (serverMessage.Contains("START"))
                    {
                        StartGame();
                        break;
                    }

                    if (serverMessage.Contains("ROOM") && serverMessage.Contains("PLAYER"))
                    {
                        string[] parts = serverMessage.Split(';');
                        string roomInfo = parts[0].Split(':')[1];
                        string playerNumber = parts[1].Split(':')[1];

                        playerNum = Int32.Parse(playerNumber);
                        UpdatePanels(playerNum + 1);
                    }

                    if (serverMessage.StartsWith("UPDATE_PANEL:"))
                    {
                        int count = int.Parse(serverMessage.Substring(13));

                        if (playerNum >= 0)  // playerNum 설정 전이면 무시
                        {
                            UpdatePanels(count);
                        }
                    }
                }
                catch (Exception ex)
                {
                    break;
                }
            }
        }

        private void UpdatePanels(int count)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdatePanels(count)));
                return;
            }

            Panel[] panels = { panel1, panel2, panel3, panel4 };
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].BackColor = (i < count) ? Color.Green : Color.Silver;
            }
        }

        private void StartGame()
        {

            if (InvokeRequired)
            {
                Invoke(new Action(StartGame));
                return;
            }

            // 기존 TcpClient 전달
            quizForm quiz = new quizForm(client, stream, playerNum, userNickname, user64Image, parentForm);
            quiz.Show();
            this.Close();
        }
    }
}
