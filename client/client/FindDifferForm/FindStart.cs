using client.quizForm;
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

        quizReady quizready;
        FindReady findReady;
        FindForm findForm;

        public FindStart()
        {
            InitializeComponent();

            /*
            // 서버에 바로 연결 (생성자 내부에서 연결)
            var client = new TcpClient("127.0.0.1", 9000);
            var stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };*/
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            findReady = new FindReady();
            //findReady.Owner = this;
            findReady.Show();
            this.Close();
            //this.Hide();

        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            //findForm = new FindForm(reader,writer);
            //findForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
