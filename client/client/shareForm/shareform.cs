using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace client.shareForm
{
    public partial class shareform : Form
    {
        private Color labelColor = Color.DimGray;
        public shareform()
        {
            InitializeComponent();
        }

        private void 나가기_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCodeItem(string title, string userID)
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
            titleLabel.Tag = userID;

            titleLabel.MouseEnter += (s, e) =>
            {
                titleLabel.ForeColor = Color.Black;
            };

            titleLabel.MouseLeave += (s, e) =>
            {
                titleLabel.ForeColor = labelColor;
            };

            Button btnGet = new Button();
            btnGet.Tag = titleLabel;
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
            string lblText = lbl.Text;
            string userId = lbl.Tag.ToString();
            
            MessageBox.Show($"유저id: [{userId}], 제목[{lblText}]"); // 나중에 지우기
            // 글 제목과 유저 id로 서버에서 CodePractice 클래스 정보 가져오기
        }
        private void Getbtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Label lbl = btn.Tag as Label;
            string lblText = lbl.Text;
            string userId = lbl.Tag.ToString();

            MessageBox.Show($"유저id: [{userId}], 제목[{lblText}]"); // 나중에 지우기
            // 글 제목과 유저 id로 서버에서 CodePractice 클래스 정보 가져오기
        }


        private void shareform_Load(object sender, EventArgs e)
        {
            //서버에서 제목 가져와서 로드
            AddCodeItem("삼성 SDS 2024 코딩테스트 기출","abc");
            AddCodeItem("백준 23021번 정답","ccc");
        }
    }
}
