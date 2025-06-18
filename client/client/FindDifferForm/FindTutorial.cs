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
    public partial class FindTutorial : Form
    {
        FindReady findReady;

        Form1 Form1;

        public FindTutorial(Form1 form1)
        {
            InitializeComponent();

            this.Form1 = form1;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "게임 방법";
        }

       
        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGameStart_Click(object sender, EventArgs e)
        {
            findReady = new FindReady(Form1);
            findReady.Show();

            this.Owner?.Close();
            this.Close();
        }
    }
}
