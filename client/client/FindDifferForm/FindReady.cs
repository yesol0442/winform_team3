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

            // 서버에 바로 연결 (생성자 내부에서 연결)
            var client = new TcpClient("127.0.0.1", 9000);
            var stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
        }

        private void gameStartBtn_Click(object sender, EventArgs e)
        {
            findForm = new FindForm(reader, writer);
            findForm.Show();
        }
    }
}
