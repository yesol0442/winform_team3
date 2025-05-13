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

namespace client.quizForm
{
    public partial class quizReady : Form
    {
        TcpClient client;
        NetworkStream stream;
        byte[] buffer = new byte[4];

        public quizReady()
        {
            InitializeComponent();
            client = new TcpClient();
            client.Connect("127.0.0.1", 9000); // 서버 IP 주소
            stream = client.GetStream();

            Thread receiveThread = new Thread(ReceiveData);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReceiveData()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[256];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    if (bytes > 0)
                    {
                        string msg = Encoding.UTF8.GetString(buffer, 0, bytes);

                        if (msg == "FULL")
                        {
                            MessageBox.Show("정원이 초과되어 접속할 수 없습니다.", "접속 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            client.Close();
                            break;
                        }

                        // 접속 인원 수인 경우
                        int count = BitConverter.ToInt32(buffer, 0);
                        UpdatePanels(count);
                    }
                }
                catch
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
    }
}
