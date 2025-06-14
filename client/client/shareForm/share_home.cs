using client.classes.NetworkManager;
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
        private UserCodeList usercodelist;
        private List<Tuple<string, int>> checkedCodeList = new List<Tuple<string, int>>();

        public share_home(string userId)
        {
            userid = userId;
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;

        }

        private async void share_home_Load(object sender, EventArgs e)
        {
            usercodelist = await GetUserCodeListAsync(userid);
            foreach (var cid_title in usercodelist.cid_title_list)
            {
                AddCodeItem(cid_title.CodeID, cid_title.Title, cid_title.status);
            }
        }

        public async Task<UserCodeList> GetUserCodeListAsync(string userId)
        {
            var nm = NetworkManager.Instance;
            await nm.SendMessageAsync($"GET_USER_CODE_LIST:{userId}\n");

            string response = await nm.ReceiveMessageAsync();
            if (response == "코드가 없습니다" || string.IsNullOrWhiteSpace(response))
                return new UserCodeList { userID = userId, cid_title_list = new List<UserCodeList.CodeItem>() };

            var list = new List<UserCodeList.CodeItem>();

            string[] entries = response.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string entry in entries)
            {
                string trimmed = entry.Trim();
                string[] parts = trimmed.Split(':');
                if (parts.Length == 3)
                {
                    string title = parts[0].Trim();
                    int codeId = int.Parse(parts[1].Trim());
                    string statusStr = parts[2].Trim();

                    int status = statusStr == "공유" ? 1 : 0;

                    list.Add(new UserCodeList.CodeItem
                    {
                        Title = title,
                        CodeID = codeId,
                        status = status
                    });
                }
            }

            return new UserCodeList
            {
                userID = userId,
                cid_title_list = list
            };
        }


        private void AddCodeItem(int codeID, string title, int status)
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
            var tag = (Tuple<string, int>)chk.Tag;
            string userID = tag.Item1;
            int codeID = tag.Item2;

            var entry = Tuple.Create(userID, codeID);

            if (chk.Checked)
            {
                if (!checkedCodeList.Contains(entry))
                {
                    checkedCodeList.Add(entry);
                }
            }
            else
            {
                if (checkedCodeList.Contains(entry))
                {
                    checkedCodeList.Remove(entry);
                }
            }

            삭제btn.Enabled = checkedCodeList.Count > 0;
        }

        private void itemPanel_Click(object sender, EventArgs e)
        {
            Panel lbl = sender as Panel;
            var tag = (Tuple<string, int>)lbl.Tag;
            string userID = tag.Item1;
            int codeID = tag.Item2;

            var parentForm = this.FindForm() as shareform;
            if (parentForm != null)
            {
                parentForm.HandleChildClick("코드수정", userID, "", codeID);
            }
        }

        private void 뒤로가기btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private async void 삭제btn_Click(object sender, EventArgs e)
        {
            List<Control> toRemove = new List<Control>();
            List<Tuple<string, int>> codesToDelete = new List<Tuple<string, int>>();

            foreach (Control panel in flowLayoutPanel1.Controls)
            {
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is CheckBox chk && chk.Checked)
                    {
                        if (chk.Tag is Tuple<string, int> tag)
                        {
                            codesToDelete.Add(tag);
                            toRemove.Add(panel);
                        }
                    }
                }
            }

            foreach (var (userId, codeId) in codesToDelete)
            {
                bool ok = await DeleteCodeAsync(codeId, userId);
                if (!ok)
                {
                    MessageBox.Show($"CodeID {codeId} 삭제 실패!");
                }
            }

            foreach (Control panel in toRemove)
            {
                flowLayoutPanel1.Controls.Remove(panel);
                panel.Dispose();
            }

            checkedCodeList.Clear();
        }

        public async Task<bool> DeleteCodeAsync(int codeId, string userId)
        {
            var nm = NetworkManager.Instance;
            string message = $"DELETE_CODE_POST:{codeId}:{Uri.EscapeDataString(userId)}\n";

            await nm.SendMessageAsync(message);
            string response = await nm.ReceiveMessageAsync();

            return response == "CODE_DELETE_SUCCESS";
        }

    }
}
