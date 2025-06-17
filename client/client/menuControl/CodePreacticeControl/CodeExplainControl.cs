using client.classes;
using client.classes.NetworkManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
            codePracticeForm.DataSent += PracticeForm_DataSent;
            codePracticeForm.ShowDialog();

        }

        private async void PracticeForm_DataSent(object sender,CodePracticeResult e)
        {
            await SendPracticeResultAsync(환경설정.currentUserId, e.TypingSpeed, e.Accuracy);
        }

        public async Task SendPracticeResultAsync(string userId, int typingSpeed, int accuracy)
        {
            var nm = NetworkManager.Instance;

            // 1. 타수 전송
            await nm.SendMessageAsync($"UPDATE_STROKE_NUMBER:{userId}:{typingSpeed}\n");
            string response1 = await nm.ReceiveMessageAsync();

            // 2. 정확도 전송
            await nm.SendMessageAsync($"UPDATE_ACCURANCY:{userId}:{accuracy}\n");
            string response2 = await nm.ReceiveMessageAsync();

            // 3. 응답 확인 (선택)
            if (response1 != "OK" || response2 != "OK")
            {
                MessageBox.Show($"업로드 실패\n타수 응답: {response1}\n정확도 응답: {response2}");
            }
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
