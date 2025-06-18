using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.HambugiGame.Controls
{
    public partial class RepeatBlockUI : UserControl
    {
        public RepeatBlockUI()
        {
            InitializeComponent();
            this.DragEnter += MyContainer_DragEnter;
            this.DragDrop += MyContainer_DragDrop;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MyContainer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Control)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MyContainer_DragDrop(object sender, DragEventArgs e)
        {
            Control droppedControl = (Control)e.Data.GetData(typeof(Control));

            droppedControl.Parent.Controls.Remove(droppedControl);

            flowLayoutPanel1.Controls.Add(droppedControl);
        }
    }
}
