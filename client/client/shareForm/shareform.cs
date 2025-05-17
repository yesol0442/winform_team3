using client.menuControl;
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
        private code_add 코드추가 = new code_add();
        private share_home 공유함홈 = new share_home();
        private share_base 기본화면 = new share_base();
        private code_detail 코드내용 = new code_detail();
        private other_home 남의홈 = new other_home();
        
        public shareform()
        {
            InitializeComponent();
            guna2Panel1.Controls.Add(코드추가);
            guna2Panel1.Controls.Add(공유함홈);
            guna2Panel1.Controls.Add(기본화면);
            guna2Panel1.Controls.Add(코드내용);
            guna2Panel1.Controls.Add(남의홈);

            // 폼 크기 고정
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void shareform_Load(object sender, EventArgs e)
        {
            기본화면.BringToFront();
            기본화면.Show();
        }

        private void 나가기_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void HandleChildClick(string message, string userID, string CodeIDORnickname)
        {
            if(message == "홈")
            {
                공유함홈.BringToFront();
                공유함홈.Show();
                return;
            }
            if(message == "코드추가")
            {
                코드추가.Initialize_code_add("", "");
                코드추가.BringToFront();
                코드추가.Show();
                return;
            }
            if(message == "코드내용")
            {
                코드내용.Initialize_codedetail(userID, CodeIDORnickname); // 코드아이디
                코드내용.BringToFront();
                코드내용.Show();
                return;

            }if(message == "남의홈")
            {
                남의홈.Initialize_otherhome(userID, CodeIDORnickname); // 닉네임
                남의홈.BringToFront();
                남의홈.Show();
                return;
            }if(message == "코드수정")
            {
                코드추가.Initialize_code_add(userID, CodeIDORnickname); // 닉네임
                코드추가.BringToFront();
                코드추가.Show();
            }
        }
    }
}
