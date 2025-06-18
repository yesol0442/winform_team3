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
using static client.OtherUserCodeList;

namespace client.shareForm
{
    public partial class other_home : UserControl
    {
        private string userid;
        private OtherUserCodeList otherusercodelist = new OtherUserCodeList();
        public other_home()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            listBox1.DisplayMember = "Title";
            listBox1.ValueMember = "CodeID";
        }

        public async Task Initialize_otherhome(string userID, string nickname)
        {
            userid = userID;
            사용자이름lbl.Text = nickname + "의";

            otherusercodelist = await GetOtherUserCodeListAsync(userID);

            listBox1.DataSource = otherusercodelist.cid_title_list;

        }

        private void 뒤로가기btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue is int codeId)
            {
                var parentForm = this.FindForm() as shareform;
                parentForm?.HandleChildClick("코드내용", userid, "", codeId);
            }
        }


        public async Task<OtherUserCodeList> GetOtherUserCodeListAsync(string userId)
        {
            var nm = NetworkManager.Instance;

            await nm.SendMessageAsync($"GET_OTHER_USER_CODE_LIST:{userId}\n");

            string response = await nm.ReceiveMessageAsync();

            if (string.IsNullOrWhiteSpace(response) || response == "코드가 없습니다")
                return new OtherUserCodeList
                {
                    userID = userId,
                    cid_title_list = new List<OtherUserCodeList.CodeItem>()
                };

            var list = new List<OtherUserCodeList.CodeItem>();

            string[] entries = response.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string entry in entries)
            {
                string[] parts = entry.Trim().Split('|');
                if (parts.Length == 2)
                {
                    string title = parts[0].Trim();
                    int codeId = int.Parse(parts[1].Trim());

                    list.Add(new OtherUserCodeList.CodeItem
                    {
                        Title = title,
                        CodeID = codeId
                    });
                }
            }

            return new OtherUserCodeList
            {
                userID = userId,
                cid_title_list = list
            };
        }

    }
}
