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
        Form1 Form1;
        private int score = 0;  // 점수 저장

        // 틀린 줄 번호 (0부터 시작)
        private List<(int line, int charIndex)> answerPositions = new List<(int, int)>
        {
            (2, 1),   // "  static void Main..." → 's' 앞 접근제한자 없던 자리
            (4, 20),  // "int number = 5" → '5' 바로 뒤 (길이 22 → 인덱스 21까지 가능)
            (5, 18),  // "Writeine"의 e
            (6, 0),   // if문의 들여쓰기 오류 (줄 시작)
            (8, 37),  // ? "Y" "N"; → "Y" 끝나는 위치 기준 (길이 안 넘도록 조정)



        };

        // 이미 맞춘 정답 좌표 리스트
        private List<(int line, int col, string player)> answeredPositions = new List<(int line, int col, string who)>();


        TransparentPanel overlayPanel = new TransparentPanel();

        private StreamWriter writer; // 서버로 메시지 전송용
        private string myId;   // 클라이언트 구분

        private Label lbScore2;
        private Label lbStatus;


        public FindForm(StreamReader reader, StreamWriter writer, string myId,Form1 form1)
        {

            this.writer = writer;
            this.myId = myId;


            InitializeComponent();

            this.Form1 = form1;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            lbNoti.AutoSize = true;
            lbNoti.Visible = false;
            lbNoti.ForeColor = Color.Crimson;


            // 투명 판넬 생성
            overlayPanel.Location = codeTxt.Location;
            overlayPanel.Size = codeTxt.Size;
            overlayPanel.Parent = this;
            
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront();
            
            // 클릭/그리기 이벤트 연결 
            overlayPanel.Paint += overlayPanel_Paint;
            overlayPanel.MouseClick += overlayPanel_MouseClick;

            // 고정폭 폰트 설정
            //codeTxt.Font = new Font("Consolas", 12);

            // 예시 코드 삽입
            LoadSampleCode();

            lbCount.Text = $"남은 개수: {answerPositions.Count}개";


            // 수신 비동기 처리
            _ = Task.Run(async () =>
            {
                try
                {
                    while (true)
                    {
                        string msg = await reader.ReadLineAsync();
                        if (!string.IsNullOrEmpty(msg))
                        {
                            Invoke((Action)(() => ProcessMessage(msg)));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[클라이언트 수신 오류] {ex.Message}");
                }
            });



        }

        private async void ShowFeedback(string text,
                                Color color,
                                int milliSeconds = 1000)
        {
            lbNoti.Text = text;
            lbNoti.ForeColor = color;
            lbNoti.Visible = true;

            await Task.Delay(milliSeconds);

            lbNoti.Visible = false;
        }

        private void LoadSampleCode()
        {
            string[] codeLines = new string[]
            {
                 "using System;",
                "public class Sample{",                         // ← 중괄호 없음
            "  static void Main(string[] args)",           // ← 접근제한자 누락 + 들여쓰기 부족
            "  {",
            "      int number = 5" ,                        // ← 세미콜론 누락
            "      Console.Writeine(number);",             // ← 오타: Writeine → WriteLine
            "    if(number > 3)",                          // ← 들여쓰기 불일치
            "    Console.WriteLine(\"Greater\");",
            "      string result = number > 3 ? \"Y\" \"N\";", // ← 삼항 연산자 오류 (콜론 누락)
            "  }",
            "}"


            };

            codeTxt.Lines = codeLines;
        }

        

        private void UpdateStatus()
        {
            int total = score + answerPositions.Count;
            lbScore2.Text = $"내 점수: {score}";
            lbStatus.Text = $"맞춘 개수: {score} / {total}";
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

            
            foreach (var (line, col, player) in answeredPositions)
            {
                answerLine = line;
                answerCol = col;

                int start = codeTxt.GetFirstCharIndexFromLine(line);
                int index = start + col;
                Point pos = codeTxt.GetPositionFromCharIndex(index);

                //Color color = player == myId ? Color.FromArgb(100, 255, 0, 0) : Color.FromArgb(100, 0, 0, 255);
                Color color = player == myId ? Color.Red : Color.Blue;

                Pen pen = new Pen(color, 3);   // 반투명 빨간색
                //g.DrawEllipse(pen, new Rectangle(pos.X+2, pos.Y+4, 14, 14));   // 동그라미
                g.DrawEllipse(pen, new Rectangle(pos.X+2, pos.Y+4, 14, 14));

            }

            /*
            foreach (var (line, col) in answerPositions)
            {
                answerLine = line;
                answerCol = col;

                int start = codeTxt.GetFirstCharIndexFromLine(line);
                int index = start + col;
                Point pos = codeTxt.GetPositionFromCharIndex(index);

                //Color color = Color.FromArgb(100, 255, 0, 0);
                Color color = Color.Red;

                Pen pen = new Pen(color, 3);   // 반투명 빨간색
                g.DrawEllipse(pen, new Rectangle(pos.X+2, pos.Y+4, 14, 14));   // 동그라미
                //g.DrawEllipse(pen, new Rectangle(pos.X, pos.Y, 14, 14));

            }*/
            //answerPositions.Remove((answerLine, answerCol));
        }

        
        private void overlayPanel_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            int index = codeTxt.GetCharIndexFromPosition(e.Location);
            int line = codeTxt.GetLineFromCharIndex(index);
            int lineStart = codeTxt.GetFirstCharIndexFromLine(line);
            int col = index - lineStart;

            var matched = answerPositions.FirstOrDefault(pos => pos.line == line && Math.Abs(pos.charIndex - col) <= 1);

            //if (answerPositions.Contains((line, col)))
            if (matched != default)
            {
                answerPositions.Remove((line, col));
                answeredPositions.Add((line, col,myId));
                score++;
                lbScore.Text = $"점수: {score}";
                overlayPanel.Invalidate(); // 다시 그리기
                
                lbCount.Text = $"남은 개수: {answerPositions.Count}개";

                var msg = new CodeGame { Type = "CLICK", Line = line, Col = col, PlayerId = myId };
                writer.WriteLine(msg.ToString());
                writer.Flush();

                if (answerPositions.Count == 0)
                { 

                    

                    Task.Run(async () =>
                    {
                        await Task.Delay(500);  // 약간의 대기
                        string endMsg = $"END {score} {myId}";
                        await writer.WriteLineAsync(endMsg);
                        await writer.FlushAsync();
                        Console.WriteLine($"[클라] END 메시지 보냄: {endMsg}");
                    });
                }

            }
            else
            {
                //MessageBox.Show("오답!");
            }*/

            Point clickPos = e.Location;
            int bestLine = -1;
            int bestCol = -1;
            double minDist = double.MaxValue;

            const int LINE_TOLERANCE = 0;   // 같은 줄만 인정 → 0
            const int COL_TOLERANCE = 3;   // 좌우 ±3 칸까지 정답 처리

            for (int line = 0; line < codeTxt.Lines.Length; line++)
            {
                int lineStart = codeTxt.GetFirstCharIndexFromLine(line);
                if (lineStart < 0) continue;

                int lineLength = codeTxt.Lines[line].Length;

                for (int col = 0; col <= lineLength; col++)  // <= 끝 위치 포함
                {
                    int index = lineStart + col;
                    Point charPos = codeTxt.GetPositionFromCharIndex(index);

                    double dist = Math.Sqrt(Math.Pow(clickPos.X - charPos.X, 2) + Math.Pow(clickPos.Y - charPos.Y, 2));
                    if (dist < minDist)
                    {
                        minDist = dist;
                        bestLine = line;
                        bestCol = col;
                    }
                }
            }

            if (bestLine != -1 && bestCol != -1)
            {
                Console.WriteLine($"[정규화된 클릭 위치] line={bestLine}, col={bestCol}");

                //var matched = answerPositions.FirstOrDefault(pos =>
                //pos.line == bestLine && Math.Abs(pos.charIndex - bestCol) <= 1);

                var matched = answerPositions.FirstOrDefault(pos =>
                                Math.Abs(pos.line - bestLine) <= LINE_TOLERANCE &&
                                Math.Abs(pos.charIndex - bestCol) <= COL_TOLERANCE);

                if (matched != default)
                {
                    answerPositions.Remove(matched);
                    answeredPositions.Add((matched.line, matched.charIndex, myId));
                    score++;
                    lbScore.Text = $"점수: {score}";
                    overlayPanel.Invalidate();

                    lbCount.Text = $"남은 개수: {answerPositions.Count}개";

                    var msg = new CodeGame { Type = "CLICK", Line = matched.line, Col = matched.charIndex, PlayerId = myId };
                    writer.WriteLine(msg.ToString());
                    writer.Flush();

                    if (answerPositions.Count == 0)
                    {
                        Task.Run(async () =>
                        {
                            await Task.Delay(500);
                            string endMsg = $"END {score} {myId}";
                            await writer.WriteLineAsync(endMsg);
                            await writer.FlushAsync();
                            Console.WriteLine($"[클라] END 메시지 보냄: {endMsg}");
                        });
                    }
                }
                else
                {
                    //MessageBox.Show("오답!");
                    ShowFeedback("오답!", Color.Gold, 1200);
                }
            }
        }

        private void ProcessMessage(string msg)
        {
            try
            {
                //Console.WriteLine($"[수신]: {msg}");

                if (msg.StartsWith("RESULT"))
                {
                    string resultText = msg.Substring(7).Trim().Replace("\\n", "\n");

                    string result;

                    if (resultText.Contains("승리"))
                        result = "승리";
                    else if (resultText.Contains("패배"))
                        result = "패배";
                    else
                        result = "무승부";

                    var endForm = new FindEnd(resultText,result,Form1);
                    endForm.ShowDialog();

                    this.Close(); // 게임 화면 닫기
                    return;
                }

                if (msg == "FORCE_END")
                {
                    string endMsg = $"END {score} {myId}";
                    writer.WriteLine(endMsg);
                    writer.Flush();
                    Console.WriteLine("[클라] FORCE_END 받아서 END 전송함");
                    return;
                }

                var gm = CodeGame.Parse(msg);

                if (gm.Type == "CLICK")
                {
                    if (answerPositions.Contains((gm.Line, gm.Col)))
                    {
                        answerPositions.Remove((gm.Line, gm.Col));
                        answeredPositions.Add((gm.Line, gm.Col, gm.PlayerId));
                        overlayPanel.Invalidate();
                        
                        lbCount.Text = $"남은 개수: {answerPositions.Count}개";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[메시지 처리 오류] {ex.Message}");
            }
        }

        private void FindForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var start = new FindStart(Form1);
            start.Show();
        }
    }
}


