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
        }

        public void Initialize_otherhome(string userID, string nickname)
        {
            userid = userID;
            otherusercodelist.userID = userID;
            사용자이름lbl.Text = nickname+"의";
            //userid로 title과 codeid 받아서 otherusercodelist만들기.
            foreach(var cid_title in otherusercodelist.cid_title_list)
            {
                listBox1.Items.Add(cid_title.ToString());
            }

        }

        private void 뒤로가기btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is CodeItem selectedItem)
            {
                string codeid = selectedItem.CodeID;

                var parentForm = this.FindForm() as shareform;
                if (parentForm != null)
                {
                    parentForm.HandleChildClick("코드내용", userid, codeid);
                }
            }
        }
    }
}
