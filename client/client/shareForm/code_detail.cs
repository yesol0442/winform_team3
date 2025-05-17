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
        private string codeid;
        private CodePractice otherusercode = new CodePractice();

        public code_detail()
        {
            InitializeComponent();
        }
        public void Initialize_codedetail(string userID, string codeID)
        {
            userid = userID;
            codeid = codeID;

            // otherusercode <= 변수 코드id와 유저 id로 서버에서 CodePractice 클래스 정보 가져오기!!!!
            exotheruser();//이건 확인용

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

        private void exotheruser()
        {
            otherusercode.userID = "eva01pilot";
            otherusercode.codeID = "operation-test-typeA";
            otherusercode.nickname = "이카리 신지";
            otherusercode.title = "에바를 타기 싫을 때 대처법";
            otherusercode.Level = 1;
            otherusercode.CodeExplanation = new List<string>
            {
                "누구도 나를 이해하지 못해...",
                "하지만 결국 난 또 에바에 타야만 했어.",
                "이건... 도망치지 않기 위한, 나만의 방법이야."
            };
            otherusercode.Code = new List<string>
            {
                "// 에바 타기 전에 반드시 확인할 것",
                "if (내마음 == 불안정)",
                "{",
                "    Misato.술을_주지마();",
                "    아버지를_직접_보지_않기();",
                "}",
                "",
                "// 탈출 시도",
                "for (int 시도 = 0; 시도 < 3; 시도++)",
                "{",
                "    도망쳐();",
                "    if (결국_탑니다)",
                "        break;",
                "}",
                "",
                "// 현실 수용",
                "print(\"나는... 또 에바에 타고 말았어\");"
            };
            otherusercode.ProfileImage = Properties.Resources.신지;
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
                parentForm.HandleChildClick("남의홈",userid,otherusercode.nickname);
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
