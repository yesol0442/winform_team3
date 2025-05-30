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
    public partial class share_base : UserControl
    {
        private Color labelColor = Color.DimGray;
        private List<CodeBriefInfo> codelist = new List<CodeBriefInfo>();
        public share_base(string userID)
        {
            InitializeComponent();
            _ = LoadSharedCodesAsync();

        }

        private async Task LoadSharedCodesAsync()
        {
            codelist = await GetSharedCodeBriefsAsync();
            foreach (CodeBriefInfo info in codelist)
            {
                AddCodeItem(info.title, info.userID, info.codeID);
            }
        }

        public async Task<List<CodeBriefInfo>> GetSharedCodeBriefsAsync()
        {
            var nm = NetworkManager.Instance;
            await nm.SendMessageAsync("GET_CODE_TITLES:\n");

            string response = await nm.ReceiveMessageAsync();

            if (string.IsNullOrWhiteSpace(response) || response == "공유된 코드가 없습니다")
                return new List<CodeBriefInfo>();

            var list = new List<CodeBriefInfo>();

            string[] entries = response.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string entry in entries)
            {
                string trimmed = entry.Trim();
                string[] parts = trimmed.Split('|');

                if (parts.Length != 3) continue;

                list.Add(new CodeBriefInfo
                {
                    title = parts[0],
                    codeID = int.Parse(parts[1]),
                    userID = parts[2]
                });
            }

            return list;
        }

        private void AddCodeItem(string title, string userID, int codeID)
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
            var tag = (Tuple<string, int>)lbl.Tag; // 타입은 실제 타입에 맞게 설정
            string userID = tag.Item1;
            int codeID = tag.Item2;

            var parentForm = this.FindForm() as shareform;
            if (parentForm != null)
            {
                parentForm.HandleChildClick("코드내용", userID, "", codeID);
            }
        }
        private async void Getbtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var tag = (Tuple<string, int>)btn.Tag;
            string userID = tag.Item1;
            int codeID = tag.Item2;

            try
            {
                ShareCodeSave shareCodeSave = await GetShareCodeSaveAsync(userID, codeID);
                if (shareCodeSave != null)
                {
                    shareCodeSave.SaveToFile();
                }
                else
                {
                    MessageBox.Show("코드를 찾을 수 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
            }
        }

        public async Task<ShareCodeSave> GetShareCodeSaveAsync(string userId, int codeId)
        {
            var nm = NetworkManager.Instance;

            // 요청 보내기
            await nm.SendMessageAsync($"GET_SHARE_CODE_SAVE:{userId}:{codeId}\n");

            // 응답 받기
            string response = await nm.ReceiveMessageAsync();

            if (response == "코드 정보를 찾을 수 없습니다")
                return null;

            string[] parts = response.Split('|');
            if (parts.Length < 5)
                return null;

            List<string> explanation = parts[3].Split('\n').ToList();
            List<string> codeLines = parts[4].Split('\n').ToList();

            return new ShareCodeSave
            {
                userID = userId,
                codeID = codeId,
                nickname = parts[0],
                title = parts[1],
                Level = int.Parse(parts[2]),
                CodeExplanation = explanation,
                Code = codeLines
            };
        }

        private void 코드추가btn_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm() as shareform;
            if (parentForm != null)
            {
                parentForm.HandleChildClick("코드추가", "", "", 0);
            }
        }

        private void 홈btn_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm() as shareform;
            if (parentForm != null)
            {
                parentForm.HandleChildClick("홈", "", "", 0);
            }
        }


    }
}
