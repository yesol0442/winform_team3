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

        public GameOver(int finalScore)
        {
            InitializeComponent();

            lbFinalScore.Text=$"점수: {finalScore}점";
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
    }
}
