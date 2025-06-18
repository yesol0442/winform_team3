using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.FindDifferForm
{
    public partial class FindTutorial : Form
    {
        FindReady findReady;

        public FindTutorial()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "게임 방법";

            label2.Text= "1. 코드에 숨겨진 오류를 찾아 마우스로 클릭하세요.\n\n" +
                "2. 오류를 더 많이 맞히는 사람이 승리합니다.\n\n" +
                "3. 정답을 클릭하면 색으로 표시됩니다.\n\n" +
                "4. 상대방의 정답도 실시간으로 확인할 수 있습니다.";
        }

       
        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGameStart_Click(object sender, EventArgs e)
        {
            findReady = new FindReady();
            findReady.Show();

            this.Owner?.Close();
            this.Close();
        }
    }
}
