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
            제목label.TextChanged += (s, e) => AutoFitLabelFont(제목label);
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

        void AutoFitLabelFont(Label label)
        {
            int fontsize = 12;
            if( 23 > label.Text.Length && label.Text.Length > 17)
            {
                fontsize = 10;
                label.Font = new Font(label.Font.FontFamily, fontsize, label.Font.Style);
            }
            else if (label.Text.Length >= 23)
            {
                fontsize = 9;
                string original = label.Text;
                string shortened = original.Substring(0, 23) + "...";
                label.Text = shortened;
                label.Font = new Font(label.Font.FontFamily, fontsize, label.Font.Style);
            }else label.Font = new Font(label.Font.FontFamily, fontsize, label.Font.Style);
        }

    }
}
