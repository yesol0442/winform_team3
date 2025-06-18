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
    public partial class quizStart : Form
    {
        quizReady quizready;
        quizForm quizform;

        Form1 parentForm;

        private string userNickname;
        private string user64Image;

        public quizStart(string nickname, string user64image, Form1 parentForm)
        {
            InitializeComponent();
            userNickname = nickname;
            user64Image = user64image;
            this.parentForm = parentForm;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            quizready = new quizReady(userNickname, user64Image, parentForm);
            quizready.ShowDialog();
        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            quizTutorial tutorial = new quizTutorial();
            tutorial.Owner = this;
            tutorial.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
