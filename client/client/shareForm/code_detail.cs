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
            userid = userID;
            codeid = codeID;
            await _codedetail(userID, codeID);
        }


        public async Task _codedetail(string userID, int codeID)
        {
            await NetworkManager.Instance.SendMessageAsync($"GET_CODE_PRACTICE:{userID}:{codeID}\n");
            string header = await NetworkManager.Instance.ReceiveHeaderAsync();
            string imageBase64 = await NetworkManager.Instance.ReceiveFullMessageUntilEndAsync("");

            string[] parts = header.Split('|');
            if (parts.Length < 6) return;

            otherusercode = new CodePractice
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
        }
    }
}
