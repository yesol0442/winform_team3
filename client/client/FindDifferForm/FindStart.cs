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

namespace client.FindDifferForm
{
    public partial class FindStart : Form
    {
        quizReady quizready;
        //FindReady findReady;
        FindForm findForm;

        public FindStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //findReady = new FindReady();
            //findReady.Owner = this;
            //findReady.Show();

            quizready = new quizReady();
            quizready.Owner = this;
            quizready.Show();
        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            findForm = new FindForm();
            findForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
