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
    public partial class CodeExplainControl : UserControl
    {
        public CodeExplainControl()
        {
            InitializeComponent();
        }

        private void 뒤로가기btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
