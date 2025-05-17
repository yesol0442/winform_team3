using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace client.shareForm
{
    public partial class code_add : UserControl
    {
        private CodePractice codeinfo = new CodePractice();
        public code_add()
        {
            InitializeComponent();
            코드내용TB.MaxLength = 2000;
            코드설명textbox.MaxLength = 100;
        }
        public void Initialize_code_add(string userid, string codeid)
        {
            if(userid != null && codeid != null)
            {
                //서버에서 사용자 id와 codeid가지고 codeinfo 채우기
                //codeinfo.nickname = 사용자 정보 처음에 가져온걸로 채우기
                codeinfo.title = 제목TB.Text;
                codeinfo.Level = 난이도CB.SelectedIndex;
                codeinfo.CodeExplanation = 코드설명textbox.Lines.ToList();
                codeinfo.Code = 코드내용TB.Lines.ToList();
                //codeinfo.ProfileImage = 사용자 정보 처음에 가져온걸로 채우기
            }
        }


        private void 텍스트파일가져오기btn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "텍스트 파일 (*.txt)|*.txt";
            openFileDialog1.Title = "텍스트 파일 선택";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog1.FileName);

                코드설명textbox.Clear();
                foreach (string line in lines)
                {
                    코드설명textbox.AppendText(line + Environment.NewLine);
                }
            }
        }

        private void 임시저장btn_Click(object sender, EventArgs e)
        {
            save_info();
            codeinfo.status = 0;
        }

        private void 업로드btn_Click(object sender, EventArgs e)
        {
            save_info();
            codeinfo.status = 1;

        }

        private void save_info()
        {
            //서버에서 사용자 id와 codeid가지고 codeinfo 채우기
            //codeinfo.nickname = 사용자 정보 처음에 가져온걸로 채우기
            codeinfo.title = 제목TB.Text;
            codeinfo.Level = 난이도CB.SelectedIndex;
            codeinfo.CodeExplanation = 코드설명textbox.Lines.ToList();
            codeinfo.Code = 코드내용TB.Lines.ToList();
            //codeinfo.ProfileImage = 사용자 정보 처음에 가져온걸로 채우기
        }

        private void 뒤로가기btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
