using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace client.FindDifferForm
{
    public partial class FindForm : Form
    {
        private int score = 0;  // 점수 저장

        // 틀린 줄 번호 (0부터 시작)
        private List<(int line, int charIndex)> wrongPositions = new List<(int, int)>
        {
            (1, 10),  // 줄 1, 10번째 문자 위치에 틀린 부분
            (3, 9)    // 줄 3, 9번째 문자 위치
        };

        // 생성한 정답 버튼을 추적하기 위한 리스트 (중복 방지, 비활성화 관리 등)
        private List<Button> answerButtons = new List<Button>();


        public FindForm()
        {
            InitializeComponent();

            // 예시 코드 삽입
            LoadSampleCode();

            // 틀린 위치에 투명 버튼 배치
            PlaceAnswerButtons();
        }


        private void LoadSampleCode()
        {
            string[] codeLines = new string[]
            {
            "using System;",
            "int a = 10",                     // ← 틀린 줄 (세미콜론 없음)
            "Console.WriteLine(a);",
            "if(a > 5)",                     // ← 틀린 줄 (중괄호 없음)
            "    Console.WriteLine(\"big\");",
            };

            codeTxt.Lines = codeLines;
        }


        // 틀린 위치에 정확한 위치로 버튼 배치
        private void PlaceAnswerButtons()
        {
            foreach (var (line, charIndex) in wrongPositions)
            {
                // 줄 시작 인덱스 + 문자 위치 = 실제 문자의 인덱스
                int lineStart = codeTxt.GetFirstCharIndexFromLine(line);
                int totalIndex = lineStart + charIndex;

                // 문자의 좌표 위치 얻기 (RichTextBox 기준)
                Point localPos = codeTxt.GetPositionFromCharIndex(totalIndex);

                // RichTextBox가 폼 안에서 떨어진 위치를 더해서 폼 좌표로 환산
                int globalX = codeTxt.Left + localPos.X;
                int globalY = codeTxt.Top + localPos.Y;

                // 버튼 생성
                Button btn = new Button
                {
                    Size = new Size(14, 18),
                    Location = new Point(globalX + 5, globalY + 1),
                    BackColor = Color.Transparent,
                    FlatStyle = FlatStyle.Flat,
                    Text = "",
                    TabStop = false
                };

                btn.FlatAppearance.BorderSize = 0;

                // 버튼 클릭 이벤트
                btn.Click += AnswerButton_Click;

                this.Controls.Add(btn);    // 폼에 추가
                btn.BringToFront();   // TextBox 위로
                answerButtons.Add(btn);     // 리스트에 저장
            }
        }

        // 버튼 클릭 시 정답 처리
        private void AnswerButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                btn.Enabled = false;
                btn.BackColor = Color.LightGreen; // 정답 시 색 표시
                score++;
                lbScore.Text = $"점수: {score}";
            }
        }
    }
}


