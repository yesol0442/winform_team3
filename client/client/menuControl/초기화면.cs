using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.menuControl
{
    public partial class 초기화면 : UserControl
    {
        public event EventHandler LoginSuccess;
        public 초기화면()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginSuccess?.Invoke(this, EventArgs.Empty);
        }
    }
}
