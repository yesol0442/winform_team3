using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.RainForm
{
    public partial class rainMain : Form
    {
        List<TextBox> Blocks=new List<TextBox>();

        // 예시
        List<string> word_list = new List<string> { "사과", "핸드폰", "커피", "물티슈", "마우스" };  
        Random rand = new Random();
        int make_count = 0;    // 블럭 생성 간격 결정
        int score = 0;

        public rainMain()
        {
            InitializeComponent();

            timer.Start();
        }

      

        private void timer_Tick(object sender, EventArgs e)
        {
            make_count++;

            if (make_count % 15 == 1)
            {
                TextBox buf = new TextBox();
                buf.Text = word_list[make_count % word_list.Count];
                buf.Location = new Point(rand.Next(10, this.ClientSize.Width - 100), 5);
                buf.Width = 100;
                buf.TextAlign = HorizontalAlignment.Center;
                buf.ReadOnly = true;
                Blocks.Add(buf);
                this.Controls.Add(buf);
                buf.BringToFront();
            }

            for (int i = Blocks.Count - 1; i >= 0; i--)
            {
                TextBox box = Blocks[i];
                int newY = box.Location.Y + 5;

                if (newY >= 470)
                {
                    // 바닥에 닿으면 제거하고 게임 오버 처리 (필요 시 구현)
                    this.Controls.Remove(box);
                    Blocks.RemoveAt(i);

                    // 여기서 게임 오버 처리 원하면 추가
                    MessageBox.Show("게임 오버!");
                    timer.Stop();
                    return;
                }
                else
                {
                    box.Location = new Point(box.Location.X, newY);
                }
            }
        }

        private void inputTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string input = inputTxt.Text.Trim();
                TextBox matchBlock = null;

                foreach (TextBox block in Blocks)
                {
                    if (block.Text == input)
                    {
                        matchBlock = block;
                        break;
                    }
                }

                if (matchBlock != null)
                {
                    this.Controls.Remove(matchBlock);
                    Blocks.Remove(matchBlock);
                    
                    score += 10;
                    lbScore.Text = $"점수: {score}";
                }

                inputTxt.Clear();
            }
        }
    }
}
