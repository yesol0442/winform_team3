using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.quizForm
{
    public partial class quizReady : Form
    {
        int playerCount = 1; //임시

        public quizReady()
        {
            InitializeComponent();
        }

        //player를 추가
        private void AddPlayer()
        {
            if (playerCount < 4)
            {
                playerCount++;
                UpdatePlayerPanels();
            }
        }

        private void UpdatePlayerPanels()
        {
            Panel[] panels = { panel1, panel2, panel3, panel4 };

            for (int i = 0; i < panels.Length; i++)
            {
                if (i < playerCount)
                {
                    panels[i].BackColor = Color.Green; // 접속한 플레이어
                }
                else
                {
                    panels[i].BackColor = Color.Silver;  // 대기 중
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AddPlayer();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
