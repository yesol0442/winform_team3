using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Threading;
using client.classes;

namespace client.BlockForm
{
    public partial class BlockGame : Form
    {
        public int time_result;

        class Question
        {
            public int blink_cnt { get; }
            public String q1 { get; }
            public String q2 { get; }
            public String[] answer { get; }

            public Question(int blink_cnt, string q1, string q2, string[] answer)
            {
                this.blink_cnt = blink_cnt;
                this.q1 = q1;
                this.q2 = q2;
                this.answer = answer;
            }
        }

        List<Question> question_list;
        int question_num;
        int blink_num;
        List<String> blink_list;

        Form1 parentForm;

        public BlockGame(Form1 main, string lang)
        {
            InitializeComponent();

            SoundManager.PlaySoundLoop(@"..\..\Resources\BlockGame.wav");

            question_list = new List<Question>();
            if (lang.Equals("C"))
            {
                intialize_question_c();
            }
            else if(lang.Equals("C++"))
            {
                intialize_question_cpp();
            }

            complete.Visible = false;
            timer_next.Enabled = false;

            parentForm = main;

            question_num = 0;
            blink_num = 0;
            blink_list = new List<string>();

            time_result = 0;
            lbl_timer.Text = time_result.ToString();
            timer_result.Enabled = true;

            NextQuestion();
        }

        private void timer_result_Tick(object sender, EventArgs e)
        {
            time_result++;
            lbl_timer.Text = time_result.ToString();
        }

        private void txt_answer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_answer.Text.Equals(question_list[question_num].answer[blink_num]))
                {
                    blink_list[blink_num + 1] = "    " + question_list[question_num].answer[blink_num] + "\r\n";
                    UpdateBlink();
                    txt_answer.Text = "";
                    blink_num++;
                }
                else
                {
                    txt_answer.Text = "";
                }

                if (blink_num == question_list[question_num].blink_cnt)
                {
                    question_num++;

                    Invoke(new Action(() =>
                    {
                        complete.Visible = true;
                    }));

                    timer_result.Enabled = false;
                    timer_next.Enabled = true;
                }
            }
        }

        private void timer_next_Tick(object sender, EventArgs e)
        {
            if (question_num == question_list.Count)
            {
                BlockResult blockResult = new BlockResult(time_result, parentForm);
                blockResult.Show();
                SoundManager.StopSound();
                this.Close();
            }
            else
            {
                NextQuestion();
                timer_result.Enabled = true;
            }
            timer_next.Enabled = false;
        }

        private void NextQuestion()
        {
            blink_list.Clear();
            blink_list.Add("\r\n");
            blink_num = 0;

            complete.Visible = false;
            lbl_q1.Text = question_list[question_num].q1;

            lbl_blink.Text = "\r\n";

            lbl_q2.Text = question_list[question_num].q2;

            Label[] labels = { block1, block2, block3, block4, block5 };
            for (int i = 0; i < 5; i++)
            {
                labels[i].Visible = false;
            }

            int n = question_list[question_num].blink_cnt;
            String[] blocks = shuffle(question_list[question_num].answer, n);
            for (int i = 0; i < n; i++)
            {
                blink_list.Add("    //빈칸 " + (i + 1) + "\r\n");
                lbl_blink.Text += blink_list[i + 1];
                labels[i].Text = blocks[i];
                labels[i].Visible = true;
            }
        }

        private String[] shuffle(String[] arr, int num)
        {
            String[] shuffled = (String[])arr.Clone();
            String temp;
            int rn;
            for (int i = 0; i < num - 1; i++)
            {
                Random random = new Random();
                rn = random.Next() % num;
                temp = String.Copy(shuffled[i]);
                shuffled[i] = String.Copy(shuffled[rn]);
                shuffled[rn] = String.Copy(temp);
            }

            return shuffled;
        }

        private void UpdateBlink()
        {
            Invoke(new Action(() =>
            {
                lbl_blink.Text = "";
                for (int i = 0; i < blink_list.Count; i++)
                {
                    lbl_blink.Text += blink_list[i];
                }
            }));
        }

        private void intialize_question_cpp()
        {
            question_list.Add(new Question(3, "\r\n#include <iostream>\r\nusing namespace std;\r\n\r\nint main() {\r\n    int arr[] = {1, 2, 3, 4, 5};\r\n    int sum = 0;",
                "\r\n    }\r\n\r\n    cout << \"합계: \" << sum << endl;\r\n    return 0;\r\n}",
                new String[] { "for (int i = 0; i < 5; i++)", "{", "sum += arr[i];" }));

            question_list.Add(new Question(5, "\r\n#include <iostream>\r\nusing namespace std;\r\n\r\nint main() {\r\n    int numbers[] = {3, 7, 2, 9, 5};\r\n    int max = numbers[0];",
                "\r\n    cout << \"최댓값: \" << max << endl;\r\n    return 0;\r\n}\r\n",
                new String[] { "for (int i = 1; i < 5; i++)", "{", "if (numbers[i] > max)", "max = numbers[i];", "}" }));
        }

        private void intialize_question_c()
        {
            question_list.Add(new Question(5, "\r\n#include <stdio.h>\r\n\r\nint main() {\r\n    int n;\r\n    printf(\"정수를 입력하세요: \");\r\n    scanf(\"%d\", &n);\r\n\r\n    int result = 1;",
                "\r\n    return 0;\r\n}",
                new String[] { "for (int i = 1; i <= n; i++)", "{", "result *= i;", "}", "printf(\"결과: %d\\n\", result);" }));

            question_list.Add(new Question(4, "\r\n#include <stdio.h>\r\n\r\nint main() {\r\n    int arr[] = {1, 2, 3, 4, 5};\r\n    int sum = 0;\r\n",
                "\r\n    printf(\"합계: %d\\n\", sum);\r\n    return 0;\r\n}\r\n",
                new String[] { "for (int i = 0; i<5; i++)", "{", "sum+= arr[i];", "}" }));
        }

        private void BlockGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            SoundManager.StopSound();
        }
    }
}
