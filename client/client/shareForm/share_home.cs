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
    public partial class share_home : UserControl
    {
        private string userid;
        private Color labelColor = Color.DimGray;
        private UserCodeList usercodelist = new UserCodeList();
        private List<Tuple<string, string>> checkedCodeList = new List<Tuple<string, string>>();

        public share_home()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;

        }

        private void share_home_Load(object sender, EventArgs e)
        {
            //userid = 로컬 db에서 가져오기 아님 전역변수 반드시
            usercodelist.userID = userid;
            //userid로 title과 codeid 받아서 otherusercodelist만들기.
            foreach (var cid_title in usercodelist.cid_title_list)
            {
                AddCodeItem(cid_title.CodeID,cid_title.Title,cid_title.status);
            }
        }

        private void AddCodeItem(string codeID, string title, int status)
        {
            Panel itemPanel = new Panel();
            itemPanel.Width = 955;
            itemPanel.Height = 40;
            itemPanel.Margin = new Padding(0, 0, 0, 2); // 아래 여백 조금

            CheckBox checkBox = new CheckBox();
            checkBox.Location = new Point(10, 12);
            checkBox.Size = new Size(20, 20);
            checkBox.Tag = Tuple.Create(userid, codeID);
            checkBox.CheckedChanged += CheckBox_CheckedChanged;

            Label titleLabel = new Label();
            titleLabel.Text = title;
            titleLabel.Font = new Font("휴먼옛체", 12F, FontStyle.Regular);
            titleLabel.AutoSize = false;
            titleLabel.Size = new Size(700, 40);
            titleLabel.Location = new Point(40, 0);
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            titleLabel.MouseEnter += (s, e) =>
            {
                titleLabel.ForeColor = Color.Black;
            };

            titleLabel.MouseLeave += (s, e) =>
            {
                titleLabel.ForeColor = labelColor;
            };


            Label statusLabel = new Label();
            statusLabel.Text = (status == 1) ? "업로드" : "임시저장";
            statusLabel.Font = new Font("휴먼옛체", 9F, FontStyle.Regular);
            statusLabel.AutoSize = true;
            statusLabel.TextAlign = ContentAlignment.MiddleRight;
            statusLabel.ForeColor = (status == 1) ? Color.Blue : Color.DimGray;

            int rightPadding = 20;
            Size textSize = TextRenderer.MeasureText(statusLabel.Text, statusLabel.Font);
            statusLabel.Location = new Point(itemPanel.Width - textSize.Width - rightPadding, 12);

            itemPanel.Controls.Add(checkBox);
            itemPanel.Controls.Add(titleLabel);
            itemPanel.Controls.Add(statusLabel);
            itemPanel.Tag = Tuple.Create(userid, codeID);
            itemPanel.Click += itemPanel_Click;

            flowLayoutPanel1.Controls.Add(itemPanel);
        }



        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            var tag = (Tuple<string, string>)chk.Tag; // 타입은 실제 타입에 맞게 설정
            string userID = tag.Item1;
            string codeID = tag.Item2;

            var entry = Tuple.Create(userID, codeID);

            if (chk.Checked)
            {
                if (!checkedCodeList.Contains(entry))
                {
                    checkedCodeList.Add(entry);
                    Console.WriteLine($"[추가] {userID}, {codeID}");
                }
            }
            else
            {
                if (checkedCodeList.Contains(entry))
                {
                    checkedCodeList.Remove(entry);
                    Console.WriteLine($"[제거] {userID}, {codeID}");
                }
            }

            삭제btn.Enabled = checkedCodeList.Count > 0;
        }

        private void itemPanel_Click(object sender, EventArgs e)
        {
            Panel lbl = sender as Panel;
            var tag = (Tuple<string, string>)lbl.Tag;
            string userID = tag.Item1;
            string codeID = tag.Item2;

            var parentForm = this.FindForm() as shareform;
            if (parentForm != null)
            {
                parentForm.HandleChildClick("코드수정", userID, codeID);
            }
        }

        private void 뒤로가기btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void 삭제btn_Click(object sender, EventArgs e)
        {
            //서버에 해당 삭제하겟다는 뭐시기 보내기.

            List<Control> toRemove = new List<Control>();
            foreach (Control panel in flowLayoutPanel1.Controls)
            {
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is CheckBox chk && chk.Checked)
                    {
                        toRemove.Add(panel);
                    }
                }
            }

            foreach (Control panel in toRemove)
            {
                flowLayoutPanel1.Controls.Remove(panel);
                panel.Dispose();
            }

            checkedCodeList.Clear();
        }
    }
}
