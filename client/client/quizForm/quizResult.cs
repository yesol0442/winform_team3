using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace client.quizForm
{
    public partial class quizResult : Form
    {
        private TcpClient client;

        public quizResult(List<PlayerResult> ranking, TcpClient client)
        {
            InitializeComponent(); // 반드시 있어야 함
            this.client = client;

            foreach (var r in ranking)
            {
                listBox1.Items.Add($"🏅 {r.Rank}위 - Player {r.Player}: {r.Score}점");
            }
        }

        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }
    }
}
