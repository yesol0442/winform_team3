using client.classes;
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
        private code_add 코드추가;
        private share_home 공유함홈;
        private share_base 기본화면;
        private code_detail 코드내용;
        private other_home 남의홈;
        private string userid = string.Empty;

        public event EventHandler<string> ChildClosed;
        public shareform()
        {
            InitializeComponent();
        }

        private async void shareform_Load(object sender, EventArgs e)
        {
            userid = 환경설정.currentUserId;
            코드추가 = new code_add();
            공유함홈 = new share_home(userid);
            기본화면 = new share_base(userid);
            코드내용 = new code_detail();
            남의홈 = new other_home();

            panel1.Controls.Add(코드추가);
            panel1.Controls.Add(기본화면);
            await 기본화면.ResetAsync(userid);
            panel1.Controls.Add(공유함홈);
            panel1.Controls.Add(코드내용);
            panel1.Controls.Add(남의홈);

            기본화면.BringToFront();
            기본화면.Show();

            // 폼 크기 고정
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }




        private void 나가기_Click(object sender, EventArgs e)
        {
            this.Close();
            ChildClosed?.Invoke(this, "자식이 닫힘");
        }

        public async void HandleChildClick(string message, string userID, string nickname, int codeID)
        {
            if (message == "홈")
            {
                await 공유함홈.ReloadAsync();
                공유함홈.BringToFront();
                공유함홈.Show();
                return;
            }
            if (message == "코드추가")
            {
                await 코드추가.Initialize_code_add(userid, 0);
                코드추가.BringToFront();
                코드추가.Show();
                return;
            }
            if (message == "코드내용")
            {
                await 코드내용.Initialize_codedetail(userID, codeID); // 코드아이디
                코드내용.BringToFront();
                코드내용.Show();
                return;

            }
            if (message == "남의홈")
            {
                await 남의홈.Initialize_otherhome(userID, nickname); // 닉네임
                남의홈.BringToFront();
                남의홈.Show();
                return;
            }
            if (message == "코드수정")
            {
                await 코드추가.Initialize_code_add(userid, codeID); // 닉네임
                코드추가.BringToFront();
                코드추가.Show();
            }
            if (message == "기본화면")
            {
                await 기본화면.ResetAsync(userid);
                기본화면.BringToFront();
                기본화면.Show();
            }
        }
    }
}
