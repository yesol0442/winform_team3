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
using System.Diagnostics;

namespace client.RainForm
{
    public partial class rainMain : Form
    {
        private string lang;
        Form1 Form1;

        List<TextBox> Blocks=new List<TextBox>();

        List<string> word_list;

        // 예시
        /*List<string> word_list = new List<string> { "Console.WriteLine", "Math.Sqrt", "ToString", "StreamReader",
    "List.Add", "string.Split", "File.Open", "DateTime.Now",
    "Convert.ToInt32", "Thread.Sleep"  };*/

        Random rand = new Random();
        int make_count = 0;    // 블럭 생성 간격 결정
        int score = 0;
        int countdownValue = 3;
        int index = 0;
        int blockSpawnInterval = 30;   // 블록 생성 간격
        int elapsedTicks = 0;          // 경과 틱 누적
        int ticksPerMinute = 100;     // 1분마다 체크
        int level = 1;

        Label levelUpLabel = null;
        Timer levelUpTimer = new Timer(); // 숨김 타이머

        public rainMain(Form1 form1,string language)
        {
            InitializeComponent();

            lang = language;
            this.Form1 = form1;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (lang == "C++") { /* C++ 문제로 초기화 */
                word_list = new List<string> { "cout", "cin", "endl", "vector", "map", "set", "string", "getline", 
                    "push_back", "emplace_back", "size", "begin", "end", "find", "erase", "insert", "sort", "swap", "pair", "make_pair", "unique",
                    "stack", "queue", "priority_queue", "to_string", "stoi", "stof", "auto", "override", "template", "lambda", "this", "nullptr", "new", "delete", "try", "catch"};
            }
            else { /* C 문제로 초기화 */
                word_list = new List<string> {"printf", "scanf", "fopen", "fclose", "fgets", "fputs", "fprintf",
                    "malloc", "free", "realloc", "exit", "atoi", "atof", "strlen", "strcpy", "strncpy", "strcmp", "strcat", "strstr", "memcpy",
                    "memset", "abs", "sqrt", "pow", "ceil", "floor", "sin", "cos", "tan", "log", "time", "clock", "srand", "rand", "qsort", "bsearch" };
            }

            this.DoubleBuffered = true;
            //timer.Start();
            lbScore.BackColor = Color.Transparent;
            inputTxt.Enabled= false;
            lbCount.Text = "3";
            lbCount.BackColor = Color.Transparent;
            lbCount.Location = new Point((this.ClientSize.Width - 60) / 2, (this.ClientSize.Height - 60) / 2);
            StartTimer.Start();

            // "Level Up!" 라벨 생성 및 설정
            levelUpLabel = new Label();
            levelUpLabel.Text = "LEVEL UP!";
            levelUpLabel.Font = new Font("휴먼옛체", 28, FontStyle.Bold);
            levelUpLabel.ForeColor = Color.Gold;
            levelUpLabel.BackColor = Color.Transparent;
            levelUpLabel.AutoSize = true;
            levelUpLabel.Visible = false;

            this.Controls.Add(levelUpLabel);

            // 숨김용 타이머 설정
            levelUpTimer.Interval = 1500; // 1.5초 후 숨김
            levelUpTimer.Tick += (s, e) =>
            {
                levelUpLabel.Visible = false;
                levelUpTimer.Stop();
            };
        }

        private void 환경설정_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            string lang = e.SelectedLanguage;

            // 언어 바뀌었을 때 처리
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            make_count++;
            elapsedTicks++;

            if (elapsedTicks >= ticksPerMinute)
            {
                if (blockSpawnInterval > 10) // 생성 간격 최소값 제한
                {
                    blockSpawnInterval -= 5; // 더 자주 생성되도록 간격 줄이기
                }


                level++; // 레벨 증가
                lbLevel.Text = $"레벨: {level}"; // 라벨 갱신


                levelUpLabel.Visible = true;
                levelUpLabel.Location = new Point(
                    (this.ClientSize.Width - levelUpLabel.Width) / 2,
                    (this.ClientSize.Height - levelUpLabel.Height) / 2 - 60
                );
                levelUpLabel.BringToFront();
                levelUpTimer.Start();

                elapsedTicks = 0;
            }

            if (make_count % blockSpawnInterval == 1)
            {
                if (index >= word_list.Count)
                {
                    index = 0;
                }
                TextBox buf = new TextBox();
                buf.Text = word_list[index];
                buf.Location = new Point(rand.Next(10, this.ClientSize.Width - 140), 5);
                buf.Width = 140;
                buf.Height = 45;
                buf.TextAlign = HorizontalAlignment.Center;
                buf.Font = new Font("휴먼옛체", 10, FontStyle.Bold);
                buf.ReadOnly = true;
                Blocks.Add(buf);
                this.Controls.Add(buf);
                buf.BringToFront();
                index++;
            }

            for (int i = Blocks.Count - 1; i >= 0; i--)
            {
                TextBox box = Blocks[i];
                int newY = box.Location.Y + 5;

                if (newY >= this.ClientSize.Height)
                {
                    // 바닥에 닿으면 제거하고 게임 오버 처리
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

            SoundManager.StopSound();

            GameOver gameOver = new GameOver(score, level, Form1);
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
            level = 1;
            lbScore.Text = "점수: 0";
            lbLevel.Text = "레벨: 1 ";

            foreach (var block in Blocks)
            {
                this.Controls.Remove(block);
            }
            Blocks.Clear();

            make_count = 0;
            blockSpawnInterval = 30;  
            elapsedTicks = 0;
            StartTimer.Start();

            SoundManager.PlaySoundLoop(@"..\..\Resources\RainGame.wav");
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

                SoundManager.PlaySoundLoop(@"..\..\Resources\RainGame.wav");
            }
        }

        private void rainMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SoundManager.StopSound();
        }
    }
}
