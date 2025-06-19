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

namespace client.HambugiGame
{
    public partial class HambugiStart : Form
    {
        public HambugiStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            HambugiGameForm ham = new HambugiGameForm();
            ham.ShowDialog();
        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            HambugiTutorial tutorial = new HambugiTutorial();
            tutorial.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
