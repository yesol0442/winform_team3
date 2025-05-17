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
        private ShareCodeSave shareCodeSave;
        public CodeExplainControl()
        {
            InitializeComponent();
        }

        private void 뒤로가기btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public void Initialization_codecontrol(ShareCodeSave scs)
        {
            코드설명textbox.Text = "";
            제목label.Text = scs.title;
            업로더lbl.Text = scs.nickname;
            string star = "";
            for (int i = 0; i < scs.Level; i++)
            {
                star += "★";
            }
            난이도lbl.Text = star;
            foreach (string n in scs.CodeExplanation)
            {
                코드설명textbox.Text += n + "\r\n";
            }
            shareCodeSave = scs;
        }

        private void 시작btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            CodePracticeForm.CodePracticeF codePracticeForm = new CodePracticeForm.CodePracticeF(shareCodeSave);
            codePracticeForm.FormClosed += (s, args) => this.Show();
            codePracticeForm.ShowDialog();

        }
    }
}
