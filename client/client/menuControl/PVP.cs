using client.quizForm;
using client.FindDifferForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client.classes;

namespace client.menuControl
{
    public partial class PVP : UserControl
    {

        quizStart quizstart;

        FindStart findStart;

        public PVP()
        {
            InitializeComponent();
        }

        private void btnQuizStart_Click(object sender, EventArgs e)
        {
            quizstart = new quizStart();
            quizstart.Show();
        }


        private void btnFindDiff_Click(object sender, EventArgs e)
        {
            findStart = new FindStart();
            findStart.Show();
        }
    }
}
