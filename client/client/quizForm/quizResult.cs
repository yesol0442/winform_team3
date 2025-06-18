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
        private int playerNum;

        private int currentScore, currentRank;
        public quizResult(List<PlayerResult> ranking, TcpClient client, Form1 parentForm, int playerNum)
        {
            InitializeComponent();
            this.client = client;
            this.playerNum = playerNum;

            foreach (var r in ranking)
            {
                if (r.Player == playerNum)
                {
                    currentScore = r.Score;
                    currentRank = r.Rank;
                }

                listBox1.Items.Add($"🏅 {r.Rank}위 - {r.Name}: {r.Score}점");
            }

            OnGameEnd(parentForm);
        }

        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }

        private async void OnGameEnd(Form1 mainForm)
        {
            await mainForm.SaveQuizResult(currentScore, currentRank);
            MessageBox.Show("점수가 저장되었습니다.");
        }
    }
}
