using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client.RainForm;

namespace client.menuControl
{
    public partial class 미니게임 : UserControl
    {
        rainMain main;

        public 미니게임()
        {
            InitializeComponent();
        }

        private void rainBtn_Click(object sender, EventArgs e)
        {
            main=new rainMain();
            main.Show();
        }
    }
}
