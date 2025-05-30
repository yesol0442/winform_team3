using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using client.classes.NetworkManager;
using static System.Windows.Forms.LinkLabel;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using static System.Windows.Forms.AxHost;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Xml.Serialization;

namespace client.shareForm
{
    public partial class code_add : UserControl
    {
        private CodePractice codeinfo = new CodePractice();
        private int codeId;
        public code_add()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            panel1.Size = new Size(980, 510);

            코드내용TB.MaxLength = 2000;
            코드설명textbox.MaxLength = 100;
            임시저장btn.Enabled = false;
            업로드btn.Enabled = false;

        }


        public async Task Initialize_code_add(string userid, int codeid)
        {
            codeId = codeid;
            codeinfo.userID = userid;

            if (userid != null && codeid != 0)
            {
                await Initialisze_codedetail(userid, codeid);

                제목TB.Text = codeinfo.title;
                난이도CB.Text = codeinfo.Level.ToString();
                코드설명textbox.Text = string.Join("\r\n", codeinfo.CodeExplanation);
                코드내용TB.Text = string.Join("\r\n", codeinfo.Code);
            }
        }

        public async Task Initialisze_codedetail(string userID, int codeID)
        {
            await NetworkManager.Instance.SendMessageAsync($"GET_CODE_PRACTICE:{userID}:{codeID}\n");
            string header = await NetworkManager.Instance.ReceiveHeaderAsync();
            string imageBase64 = await NetworkManager.Instance.ReceiveFullMessageUntilEndAsync("");

            string[] parts = header.Split('|');
            if (parts.Length < 6) return;

            codeinfo = new CodePractice
            {
                userID = userID,
                codeID = codeID,
                nickname = parts[0],
                title = parts[1],
                Level = int.Parse(parts[2]),
                ProfileImageData = Convert.FromBase64String(imageBase64),
                status = 1,
                CodeExplanation = parts[4].Split('\n').ToList(),
                Code = parts[5].Split('\n').ToList()
            };
        }


        private void 텍스트파일가져오기btn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "텍스트 파일 (*.txt)|*.txt";
            openFileDialog1.Title = "텍스트 파일 선택";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog1.FileName);

                코드내용TB.Clear();
                foreach (string line in lines)
                {
                    코드내용TB.AppendText(line + Environment.NewLine);
                }
            }
        }

        private async void 임시저장btn_Click(object sender, EventArgs e)
        {
            save_info();
            codeinfo.status = 0;
            string ex = string.Join("\n", codeinfo.CodeExplanation.Where(s => !string.IsNullOrWhiteSpace(s)));
            string code = string.Join("\n", codeinfo.Code.Where(s => !string.IsNullOrWhiteSpace(s)));
            if (codeId != 0)
            {
                bool ok = await UpdateCodeWithStatusAsync(codeId, codeinfo.userID, codeinfo.title, codeinfo.Level, "", ex, code, false);
                MessageBox.Show(ok ? "임시저장 성공!" : "임시저장 실패!");
            }
            else
            {
                bool ok = await InsertCodeWithStatusAsync(codeinfo.userID, codeinfo.title, codeinfo.Level, "", ex, code, true);
                MessageBox.Show(ok ? "임시저장 성공!" : "임시저장 실패!");
            }

        }

        private async void 업로드btn_Click(object sender, EventArgs e)
        {
            save_info();
            codeinfo.status = 1;
            string ex = string.Join("\n", codeinfo.CodeExplanation.Where(s => !string.IsNullOrWhiteSpace(s)));
            string code = string.Join("\n", codeinfo.Code.Where(s => !string.IsNullOrWhiteSpace(s)));
            if (codeId != 0)
            {
                bool ok = await UpdateCodeWithStatusAsync(codeId, codeinfo.userID, codeinfo.title, codeinfo.Level, "", ex, code, false);
                MessageBox.Show(ok ? "업로드 성공!" : "업로드 실패!");
            }
            else
            {
                bool ok = await InsertCodeWithStatusAsync(codeinfo.userID, codeinfo.title, codeinfo.Level, "", ex, code, true);
                MessageBox.Show(ok ? "업로드 성공!" : "업로드 실패!");
            }
        }

        private void save_info()
        {
            codeinfo.title = 제목TB.Text;
            codeinfo.Level = 난이도CB.SelectedIndex;
            codeinfo.CodeExplanation = 코드설명textbox.Lines.ToList();
            codeinfo.Code = 코드내용TB.Lines.ToList();

        }

        public async Task<bool> UpdateCodeWithStatusAsync(int codeId, string userId, string title, int level, string source, string desc, string content, bool status)
        {
            var nm = NetworkManager.Instance;

            string Encode(string s) => Uri.EscapeDataString(s);

            string message = $"UPDATE_CODE_POST:{codeId}:{Encode(userId)}:{Encode(title)}:{level}:{Encode(source)}:{Encode(desc)}:{Encode(content)}:{status.ToString().ToLower()}\n";

            await nm.SendMessageAsync(message);
            string response = await nm.ReceiveMessageAsync();

            return response == "CODE_UPDATE_SUCCESS";
        }


        public async Task<bool> InsertCodeWithStatusAsync(string userId, string title, int level, string source, string desc, string content, bool shareStatus)
        {
            var nm = NetworkManager.Instance;

            string Encode(string s)
            {
                return Uri.EscapeDataString(s);
            }

            string message = $"INSERT_CODE_POST:" +
                $"{Encode(userId)}:{Encode(title)}:{level}:{Encode(source)}:" +
                $"{Encode(desc)}:{Encode(content)}:{shareStatus.ToString().ToLower()}\n";

            await nm.SendMessageAsync(message);
            string response = await nm.ReceiveMessageAsync();

            return response == "CODE_INSERT_SUCCESS";
        }



        private void 뒤로가기btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            임시저장btn.Enabled = !string.IsNullOrWhiteSpace(코드내용TB.Text) && !string.IsNullOrWhiteSpace(코드설명textbox.Text);
            업로드btn.Enabled = !string.IsNullOrWhiteSpace(코드내용TB.Text) && !string.IsNullOrWhiteSpace(코드설명textbox.Text);
        }


        private void code_add_Load(object sender, EventArgs e)
        {

        }
    }
}
