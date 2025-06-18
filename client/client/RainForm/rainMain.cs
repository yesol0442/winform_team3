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
using client.classes;

namespace client.RainForm
{
    public partial class rainMain : Form
    {
        private 환경설정 환경설정컨트롤;

        List<TextBox> Blocks=new List<TextBox>();

        // 예시
        List<string> word_list = new List<string> { "사과", "핸드폰", "커피", "물티슈", "마우스" };  
        Random rand = new Random();
        int make_count = 0;    // 블럭 생성 간격 결정
        int score = 0;
        int countdownValue = 3;

        public rainMain()
        {
            InitializeComponent();

            환경설정컨트롤 = new 환경설정();
            환경설정컨트롤.LanguageChanged += 환경설정_LanguageChanged;

            this.DoubleBuffered = true;
            //timer.Start();
            lbScore.BackColor = Color.Transparent;
            inputTxt.Enabled= false;
            lbCount.Text = "3";
            lbCount.BackColor = Color.Transparent;
            lbCount.Location = new Point((this.ClientSize.Width - 60) / 2, (this.ClientSize.Height - 60) / 2);
            StartTimer.Start();
        }

        private void 환경설정_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            string lang = e.SelectedLanguage;

            // 언어 바뀌었을 때 처리
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            make_count++;

            if (make_count % 30 == 1)
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

                if (newY >= this.ClientSize.Height)
                {
                    // 바닥에 닿으면 제거하고 게임 오버 처리 (필요 시 구현)
                    this.Controls.Remove(box);
                    Blocks.RemoveAt(i);

                    /*
                    // 여기서 게임 오버 처리 원하면 추가
                    MessageBox.Show("게임 오버!");
                    timer.Stop();*/
                    GameOver();
                    //return;
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


        private void GameOver()
        {
            timer.Stop();

            GameOver gameOver = new GameOver(score);
            gameOver.StartPosition = FormStartPosition.CenterParent;
            gameOver.ShowDialog();

            if (gameOver.RestartRequested)
            {
                RestartGame();
            }
            else
            {
                this.Close();
            }
        }

        // 다시 시작
        private void RestartGame()
        {
            score = 0;
            lbScore.Text = "점수: 0";

            foreach (var block in Blocks)
            {
                this.Controls.Remove(block);
            }
            Blocks.Clear();

            make_count = 0;
            StartTimer.Start();
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            if (countdownValue > 1)
            {
                countdownValue--;
                lbCount.Text= countdownValue.ToString();
            }
            else if(countdownValue ==1)
            {
                countdownValue--;
                lbCount.Location = new Point((this.ClientSize.Width-120) / 2, (this.ClientSize.Height - 60) / 2);
                lbCount.Text = "시작!";
            }
            else
            {
                StartTimer.Stop();
                this.Controls.Remove(lbCount);
                inputTxt.Enabled = true;
                timer.Start();
            }
        }
    }
}
