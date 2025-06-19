using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client.HambugiGame;
using client.RainForm;

namespace client.menuControl
{
    public partial class 미니게임 : UserControl
    {
        public event EventHandler RainButtonClicked;
        public event EventHandler BlockButtonClicked;

        public 미니게임()
        {
            InitializeComponent();
        }

        private void rainBtn_Click(object sender, EventArgs e)
        {
            RainButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void blockBtn_Click(object sender, EventArgs e)
        {
            BlockButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            HambugiStart hambugiStart = new HambugiStart();
            hambugiStart.ShowDialog();
        }
    }
}
