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
        private string _userId = string.Empty;
        public share_base(string userID)
        {
            InitializeComponent();
            _userId = userID;            // 필드로 보관
            this.Dock = DockStyle.Fill;

        }

        private async void share_base_Load(object sender, EventArgs e)
        {
            await ResetAsync(_userId);
        }
        public async Task ResetAsync(string userId)
        {
            flowLayoutPanel1.Controls.Clear();
            codelist = await GetSharedCodeBriefsAsync(userId);
            foreach (CodeBriefInfo info in codelist)
            {
                AddCodeItem(info.title, info.userID, info.codeID);
            }
        }


        public async Task<List<CodeBriefInfo>> GetSharedCodeBriefsAsync(string userID)
        {
            var nm = NetworkManager.Instance;
            await nm.SendMessageAsync($"GET_CODE_TITLES:{userID}\n");

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
                    title = Uri.UnescapeDataString(parts[0]),
                    codeID = int.Parse(parts[1]),
                    userID = Uri.UnescapeDataString(parts[2])
                });
            }

            return list;
        }

        private void AddCodeItem(string title, string userID, int codeID)
        {
            if (this.InvokeRequired)
            {
                // UI 스레드에 처리를 위임하고 종료
                this.Invoke(new Action(() => AddCodeItem(title, userID, codeID)));
                return;
            }
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
            titleLabel.ForeColor = labelColor;

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
            btnGet.Location = new Point(itemPanel.Width - 130, 3);
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
                    MessageBox.Show("저장 되었습니다.");
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
            await nm.SendMessageAsync($"GET_CODE_PRACTICE:{userId}:{codeId}\n");

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
                return null;

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

            return new ShareCodeSave
            {
                userID = userId,
                codeID = codeId,
                nickname = Uri.UnescapeDataString(parts[0]).Trim(),
                title = Uri.UnescapeDataString(parts[1]),
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
