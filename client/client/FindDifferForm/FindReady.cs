using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.FindDifferForm
{
    public partial class FindReady : Form
    {
        private StreamReader reader;
        private StreamWriter writer;

        FindForm findForm;

        public FindReady()
        {
            InitializeComponent();

            ConnectToServer();

            

        }


        private async void ConnectToServer()
        {
            var client = new TcpClient("127.0.0.1", 9000);
            var stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };

            string playerId = "";

            // 대기 메시지 받기
            while (true)
            {
                string msg = await reader.ReadLineAsync();

                if (msg.StartsWith("ID"))
                {
                    // ex: "ID A" 또는 "ID B"
                    playerId = msg.Substring(3).Trim();
                    Console.WriteLine($"플레이어 ID 수신: {playerId}");

                    //panel1.BackColor = Color.Lime;
                    //if (playerId == "A") panel1.BackColor = Color.Lime;
                    //if (playerId == "B") panel2.BackColor = Color.Lime;
                    Invoke((Action)(() =>
                    {
                        if (playerId == "A") panel1.BackColor = Color.Lime;
                        if (playerId == "B") panel2.BackColor = Color.Lime;
                    }));

                    continue;
                }
                else if (msg == "OTHER_CONNECTED")
                {
                    Invoke((Action)(() =>
                    {
                        if (playerId == "A") panel2.BackColor = Color.Lime;
                        else if (playerId == "B") panel1.BackColor = Color.Lime;
                    }));
                }

                if (msg == "START")
                {
                    await Task.Delay(1000);
                    Invoke((Action)(() =>
                    {
                        var findForm = new FindForm(reader, writer,playerId);
                        findForm.Show();
                        this.Hide();  // 대기창 숨김
                    }));
                    break;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindReady_FormClosed(object sender, FormClosedEventArgs e)
        {
            var start = new FindStart();
            start.Show();
        }
    }
}
