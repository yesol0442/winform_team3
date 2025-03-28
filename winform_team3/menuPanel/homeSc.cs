using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_team3.menuPanel
{
    public partial class homeSc : UserControl
    {
        public homeSc()
        {
            InitializeComponent();
        }

        private void shareBeebtn_MouseEnter(object sender, EventArgs e)
        {
            shareBeebtn.BackgroundImage = Properties.Resources.shareBee2;
        }

        private void homeSc_Load(object sender, EventArgs e)
        {
            shareBeebtn.BackgroundImage = Properties.Resources.shareBee1;
            shareBeebtn.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void shareBeebtn_MouseLeave(object sender, EventArgs e)
        {
            shareBeebtn.BackgroundImage = Properties.Resources.shareBee1;
        }

        private void shareBeebtn_Click(object sender, EventArgs e)
        {
            ShareBee shareBeeform = new ShareBee();
            shareBeeform.Show();
        }
    }
}
