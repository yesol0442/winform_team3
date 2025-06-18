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
    public partial class FindEnd : Form
    {
        public FindEnd(string resultMessage)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "게임 결과";

            lbResult.Text = resultMessage;

        }


        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
