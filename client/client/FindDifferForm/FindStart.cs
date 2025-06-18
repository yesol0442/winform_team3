using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;



namespace client.FindDifferForm
{
    public partial class FindStart : Form
    {
        private StreamReader reader;
        private StreamWriter writer;

        FindReady findReady;
        FindForm findForm;
        FindTutorial findTutorial;
        Form1 Form1;

        public FindStart(Form1 form1)
        {
            InitializeComponent();

            this.Form1 = form1;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "시작 화면";

            /*
            // 서버에 바로 연결 (생성자 내부에서 연결)
            var client = new TcpClient("127.0.0.1", 9000);
            var stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };*/
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            findReady = new FindReady(Form1);
            //findReady.Owner = this;
            findReady.Show();
            this.Close();
            //this.Hide();

        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            findTutorial = new FindTutorial(Form1);
            //findTutorial.Show();
            findTutorial.Owner = this;
            findTutorial.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
