using client.classes;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private List<(int line, int charIndex)> answerPositions = new List<(int, int)>
        {
            (1, 10),  // 줄 1, 10번째 문자 위치에 틀린 부분
            (3, 9)    // 줄 3, 9번째 문자 위치
        };

        // 이미 맞춘 정답 좌표 리스트
        private List<(int line, int col)> answeredPositions = new List<(int, int)>();


        TransparentPanel overlayPanel = new TransparentPanel();

        private StreamWriter writer; // 서버로 메시지 전송용

        public FindForm(StreamReader reader, StreamWriter writer)
        {

            this.writer = writer;

            InitializeComponent();

            // 투명 판넬 생성
            overlayPanel.Location = codeTxt.Location;
            overlayPanel.Size = codeTxt.Size;
            overlayPanel.Parent = this;
            
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront();
            
            // 클릭/그리기 이벤트 연결 
            overlayPanel.Paint += overlayPanel_Paint;
            overlayPanel.MouseClick += overlayPanel_MouseClick;

            // 예시 코드 삽입
            LoadSampleCode();


            // 수신 비동기 처리
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    string msg = await reader.ReadLineAsync();
                    if (!string.IsNullOrEmpty(msg))
                    {
                        Invoke((Action)(() => ProcessMessage(msg)));
                    }
                }
            });



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

        
       

        private void overlayPanel_Paint(object sender, PaintEventArgs e)
        {
            /*
            // 테스트용
            Graphics g = e.Graphics;
            // Brush brush = new SolidBrush(Color.FromArgb(80, Color.Red));
            


            foreach (var (line, col) in answerPositions)
            {
                int start = codeTxt.GetFirstCharIndexFromLine(line);
                int index = start + col;
                Point pos = codeTxt.GetPositionFromCharIndex(index);

                Pen pen = new Pen(Color.Green, 2);
                g.DrawEllipse(pen, new Rectangle(pos.X, pos.Y, 14, 14));
            }*/


            // 투명
            
            Graphics g = e.Graphics;

            int answerLine=0;
            int answerCol=0;

            foreach (var (line, col) in answeredPositions)
            {
                answerLine = line;
                answerCol = col;

                int start = codeTxt.GetFirstCharIndexFromLine(line);
                int index = start + col;
                Point pos = codeTxt.GetPositionFromCharIndex(index);

                Pen pen = new Pen(Color.FromArgb(100, 255, 0, 0), 3);   // 반투명 빨간색
                g.DrawEllipse(pen, new Rectangle(pos.X+2, pos.Y+4, 14, 14));   // 동그라미
             
            }
           answeredPositions.Remove((answerLine, answerCol));
        }


        private void overlayPanel_MouseClick(object sender, MouseEventArgs e)
        {
            int index = codeTxt.GetCharIndexFromPosition(e.Location);
            int line = codeTxt.GetLineFromCharIndex(index);
            int lineStart = codeTxt.GetFirstCharIndexFromLine(line);
            int col = index - lineStart;

            if (answerPositions.Contains((line, col)))
            {
                answerPositions.Remove((line, col));
                answeredPositions.Add((line, col));
                score++;
                lbScore.Text = $"점수: {score}";
                overlayPanel.Invalidate(); // 다시 그리기

                var msg = new CodeGame { Type = "CLICK", Line = line, Col = col };
                writer.WriteLine(msg.ToString());
            }
            else
            {
                MessageBox.Show("오답!");
            }
        }

        private void ProcessMessage(string msg)
        {
            var gm = CodeGame.Parse(msg);
            if (gm.Type == "CLICK")
            {
                if (answerPositions.Contains((gm.Line, gm.Col)))
                {
                    answeredPositions.Remove((gm.Line, gm.Col));
                    overlayPanel.Invalidate();
                }
            }
        }
    }
}


