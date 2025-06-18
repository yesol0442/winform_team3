using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.RainForm
{
    public partial class GameOver : Form
    {
        public bool RestartRequested { get; private set; } = false;

        Form1 Form1;
        private int finalScore;
        private int finalLevel;

        public GameOver(int finalScore, int finalLevel, Form1 form1)
        {
            InitializeComponent();

            this.Form1 = form1;

            this.finalScore = finalScore;
            this.finalLevel = finalLevel;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "게임 오버";

            lbFinalScore.Text=$"점수: {finalScore}점";

            lbLevel.Text = $"레벨: {finalLevel}";

            OnGameEnd(form1);
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            RestartRequested = true;
            this.Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            RestartRequested = false;
            this.Close();
        }

        private async void OnGameEnd(Form1 form)
        {
            await form.SaveRainResult(finalScore, finalLevel);

        }
    }
}
