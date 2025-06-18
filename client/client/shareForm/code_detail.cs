using client.classes.NetworkManager;
using client.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.shareForm
{
    public partial class code_detail : UserControl
    {
        private string userid;
        private int codeid;
        private CodePractice otherusercode = new CodePractice();

        public code_detail()
        {
            InitializeComponent();

        }
        public async Task Initialize_codedetail(string userID, int codeID)
        {
            제목lbl.Text = "";
            난이도lbl.Text = "";
            코드설명textbox.Text = "";
            코드내용TB.Text = "";

            userid = userID;
            codeid = codeID;
            await _codedetail(userID, codeID);
        }


        public async Task _codedetail(string userID, int codeID)
        {
            var nm = NetworkManager.Instance;
            await nm.SendMessageAsync($"GET_CODE_PRACTICE:{userID}:{codeID}\n");

            // 헤더 수신
            StringBuilder headerBuilder = new StringBuilder();
            string chunk;
            while (true)
            {
                chunk = await nm.ReceiveMessageAsync();
                if (chunk.Contains("::END_HEADER::"))
                {
                    int idx = chunk.IndexOf("::END_HEADER::");
                    headerBuilder.Append(chunk.Substring(0, idx));
                    chunk = chunk.Substring(idx + "::END_HEADER::".Length);
                    break;
                }
                else
                {
                    headerBuilder.Append(chunk);
                }
            }

            string[] parts = headerBuilder.ToString().Split('|');
            if (parts.Length < 5)
            {
                MessageBox.Show("오류");
                return;
            }

            StringBuilder imageBuilder = new StringBuilder();
            if (!chunk.Contains("::END::"))
                imageBuilder.Append(chunk);

            while (!chunk.Contains("::END::"))
            {
                chunk = await nm.ReceiveMessageAsync();
                if (chunk.Contains("::END::"))
                {
                    int endIdx = chunk.IndexOf("::END::");
                    imageBuilder.Append(chunk.Substring(0, endIdx));
                    break;
                }
                else
                {
                    imageBuilder.Append(chunk);
                }
            }

            byte[] profileImageBytes = Convert.FromBase64String(imageBuilder.ToString());

            List<string> explanation = Uri.UnescapeDataString(parts[3]).Split('\n').ToList();
            List<string> codeLines = Uri.UnescapeDataString(parts[4]).Split('\n').ToList();

            otherusercode = new CodePractice
            {
                userID = userID,
                codeID = codeID,
                nickname = Uri.UnescapeDataString(parts[0]).Trim(),
                title = Uri.UnescapeDataString(parts[1]).Trim(),
                Level = int.Parse(parts[2]),
                ProfileImageData = profileImageBytes,
                status = 1,
                CodeExplanation = explanation,
                Code = codeLines
            };

            닉네임lbl.Text = otherusercode.nickname;
            제목lbl.Text = otherusercode.title;
            string star = "";
            for (int i = 0; i < otherusercode.Level; i++)
            {
                star += "★";
            }
            난이도lbl.Text = star;
            foreach (string n in otherusercode.CodeExplanation)
            {
                코드설명textbox.Text += n + "\r\n";
            }
            foreach (string n in otherusercode.Code)
            {
                코드내용TB.Text += n + "\r\n";
            }
            pictureBox1.Image = otherusercode.ProfileImage;
        }


        private void 뒤로가기btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void 닉네임lbl_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm() as shareform;
            if (parentForm != null)
            {
                parentForm.HandleChildClick("남의홈", userid, otherusercode.nickname, 0);
            }
        }

        private void 가져오기btn_Click(object sender, EventArgs e)
        {
            ShareCodeSave shareCodeSave = new ShareCodeSave
            {
                userID = otherusercode.userID,
                codeID = otherusercode.codeID,
                nickname = otherusercode.nickname,
                title = otherusercode.title,
                Level = otherusercode.Level,
                CodeExplanation = otherusercode.CodeExplanation,
                Code = otherusercode.Code
            };

            // 저장
            shareCodeSave.SaveToFile();
            MessageBox.Show("저장됨");
        }

        private void 난이도lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
