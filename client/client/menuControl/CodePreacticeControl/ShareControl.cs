using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.menuControl.CodePreacticeControl
{
    public partial class ShareControl : UserControl
    {
        public event EventHandler<string> NotifyParent;
        public ShareControl()
        {
            InitializeComponent();
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.shareBee2;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.shareBee1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            shareForm.shareform shareBeeform = new shareForm.shareform();
            shareBeeform.ChildClosed += (s, msg) =>
            {
                NotifyParent?.Invoke(this, "초기화필요");
            };
            shareBeeform.ShowDialog();
        }

        private void ShareControl_Load(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.shareBee1;
        }
    }
}
