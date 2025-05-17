using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.shareForm
{
    public partial class share_base : UserControl
    {
        private Color labelColor = Color.DimGray;
        private List<CodeBriefInfo> codelist = new List<CodeBriefInfo>();
        public share_base()
        {
            InitializeComponent();
            //서버에서 CodeBriefInfo들을 list에 담아 가져오기
            foreach(CodeBriefInfo info in codelist)
            {
                AddCodeItem(info.title, info.userID, info.codeID);
            }
            AddCodeItem("에바를 타기 싫을 때 대처법", "eva01pilot", "operation-test-typeA");//나중에 없애기
            AddCodeItem("백준 23021번 정답", "ccc", "33");
        }

        private void AddCodeItem(string title, string userID, string codeID)
        {
            Panel itemPanel = new Panel();
            itemPanel.Width = flowLayoutPanel1.Width - 25;
            itemPanel.Height = 35;
            itemPanel.BackColor = Color.White;

            Label titleLabel = new Label();
            titleLabel.Text = title;
            titleLabel.AutoSize = false;
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            titleLabel.Width = 260;
            titleLabel.Height = 35;
            titleLabel.Location = new Point(10, 0);
            titleLabel.Font = new Font("휴먼옛체", 10, FontStyle.Regular);
            titleLabel.Click += Label_Click;
            titleLabel.Tag = Tuple.Create(userID, codeID);

            titleLabel.MouseEnter += (s, e) =>
            {
                titleLabel.ForeColor = Color.Black;
            };

            titleLabel.MouseLeave += (s, e) =>
            {
                titleLabel.ForeColor = labelColor;
            };

            Button btnGet = new Button();
            btnGet.Tag = Tuple.Create(userID, codeID);
            btnGet.Text = "가져오기";
            btnGet.Size = new Size(80, 30);
            btnGet.Location = new Point(462, 3);
            btnGet.Font = new Font("휴먼옛체", 9, FontStyle.Regular);
            btnGet.Click += Getbtn_Click;

            itemPanel.Controls.Add(titleLabel);
            itemPanel.Controls.Add(btnGet);

            flowLayoutPanel1.Controls.Add(itemPanel);
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            var tag = (Tuple<string, string>)lbl.Tag; // 타입은 실제 타입에 맞게 설정
            string userID = tag.Item1;
            string codeID = tag.Item2;

            MessageBox.Show($"유저id: [{userID}], 코드 아이디[{codeID}]"); // 나중에 지우기
            var parentForm = this.FindForm() as shareform;
            if (parentForm != null)
            {
                parentForm.HandleChildClick("코드내용",userID,codeID);
            }
        }
        private void Getbtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var tag = (Tuple<string, string>)btn.Tag; // 타입은 실제 타입에 맞게 설정
            string userID = tag.Item1;
            string codeID = tag.Item2;

            //내부에 text파일로 저장
            ShareCodeSave shareCodeSave = new ShareCodeSave();// 여기다가 저장
            //파일 가져오기
            shareCodeSave.SaveToFile();
        }

        private void 코드추가btn_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm() as shareform;
            if (parentForm != null)
            {
                parentForm.HandleChildClick("코드추가","","");
            }
        }

        private void 홈btn_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm() as shareform;
            if (parentForm != null)
            {
                parentForm.HandleChildClick("홈","","");
            }
        }
    }
}
