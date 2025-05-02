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
    public partial class 코드연습 : UserControl
    {
        private CodePreacticeControl.ShareControl sharecontrol = new CodePreacticeControl.ShareControl();
        private CodePreacticeControl.CodeExplainControl codecontrol = new CodePreacticeControl.CodeExplainControl();
        public 코드연습()
        {
            InitializeComponent();
            panel2.Controls.Add(sharecontrol);
            panel2.Controls.Add(codecontrol);

        }

        private void 코드연습_Load(object sender, EventArgs e)
        {
            //로컬DB에서 title 가져와서 listbox에 추가
            sharecontrol.BringToFront();
            sharecontrol.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            codecontrol.BringToFront();
            codecontrol.Show();
        }


    }
}
