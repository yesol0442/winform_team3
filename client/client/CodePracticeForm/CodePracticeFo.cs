using client.classes;
using client.menuControl;
using client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.CodePracticeForm
{
    public partial class CodePracticeFo : Form
    {
        private 환경설정 환경설정컨트롤;

        private readonly ShareCodeSave shareCodeSave;
        private DateTime? _startTime = null;

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowCaret(IntPtr hWnd);


        private readonly Dictionary<RichTextBox, int> _prevLen = new Dictionary<RichTextBox, int>();
        private readonly Dictionary<RichTextBox, int> _prevErrors = new Dictionary<RichTextBox, int>();

        private readonly int _totalLines;
        private int _finishedLines = 0;
        private readonly HashSet<int> _doneRows = new HashSet<int>();

        private int _totalTyped = 0;
        private int _totalErrors = 0;

        private int code_line_num = 0;

        private Font codeFont = new Font("굴림체", 12f, FontStyle.Regular, GraphicsUnit.Pixel);

        public event EventHandler<CodePracticeResult> DataSent;

        // 타자 가이드
        private PictureBox kbBase;          // 키보드 사진
        private PictureBox kbOverlay;       // 투명한 오버레이 – 강조 사각형을 그릴 캔버스
        private readonly Dictionary<char, Rectangle> keyMap = new Dictionary<char, Rectangle>(); // 문자→키 좌표
        string imgPath = @"C:\Users\cheae\source\repos\winform_team3\client\client\Resources\키보드.png";
        private int _linesPerPage = 13;





        public CodePracticeFo(ShareCodeSave scs, 환경설정 settings)
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;


            this.환경설정컨트롤 =settings;
            settings.CheckBoxChecked += 환경설정_CheckBoxChecked;


            shareCodeSave = scs;
            code_line_num = scs.Code.Count;
            _totalLines = scs.Code.Count;

            InitKeyboard();

            if (settings.IsGuideChecked)
            {
                _linesPerPage = 10;
                kbBase.Visible = true;

            }


        }

        private void 환경설정_CheckBoxChecked(object sender, EventArgs e)
        {

            if (_linesPerPage == 10) return;         // 이미 10줄이면 무시

            _linesPerPage = 10;                      // ① 페이지당 10줄
            kbBase.Visible = true;                  // ② 키보드 그림 표시
        }

        void InitKeyboard()
        {

            // (1) 바탕 사진
            kbBase = new PictureBox
            {


                Image = Image.FromFile(imgPath),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Bottom,
                Height = 250,     // 사진 높이(마음대로)
                Visible=false
            };
            // (2) 반투명 오버레이 – 키 강조용
            kbOverlay = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            kbBase.Controls.Add(kbOverlay);
            this.Controls.Add(kbBase);      // 폼 제일 밑에 깔기
            kbBase.BringToFront();          // 필요하면 BringToFront

            BuildKeyMap();                  // 문자→좌표 사전 작성
        }


        void BuildKeyMap()
        {
            /*
            // ※ 키보드 PNG 안에서 각 키의 픽셀 위치·크기를 직접 재서 채워넣어야 합니다.
            //    숫자는 예시입니다.
            keyMap['a'] = new Rectangle(50, 90, 40, 40);
            keyMap['b'] = new Rectangle(170, 130, 40, 40);
            keyMap['c'] = new Rectangle(110, 130, 40, 40);
            // … 나머지 모든 키
            keyMap['A'] = keyMap['a'];      // 대소문자 동일 좌표
            keyMap['{'] = keyMap['['];      // 중괄호 등도 동일 키*/

            // ───────── 숫자줄 ─────────
            keyMap['`'] = keyMap['~'] = new Rectangle(23, 12, 80, 40);
            keyMap['1'] = keyMap['!'] = new Rectangle(117, 12, 80, 40);
            keyMap['2'] = keyMap['@'] = new Rectangle(211, 12, 80, 40);
            keyMap['3'] = keyMap['#'] = new Rectangle(305, 12, 80, 40);
            keyMap['4'] = keyMap['$'] = new Rectangle(399, 12, 80, 40);
            keyMap['5'] = keyMap['%'] = new Rectangle(493, 12, 80, 40);
            keyMap['6'] = keyMap['^'] = new Rectangle(587, 12, 80, 40);
            keyMap['7'] = keyMap['&'] = new Rectangle(681, 12, 80, 40);
            keyMap['8'] = keyMap['*'] = new Rectangle(775, 12, 80, 40);
            keyMap['9'] = keyMap['('] = new Rectangle(869, 12, 80, 40);
            keyMap['0'] = keyMap[')'] = new Rectangle(963, 12, 80, 40);
            keyMap['-'] = keyMap['_'] = new Rectangle(1057, 12, 80, 40);   
            keyMap['='] = keyMap['+'] = new Rectangle(1151, 12, 80, 40);
            //keyMap['\b'] = new Rectangle(618, 20, 86, 40); // Backspace

            // ───────── Tab + QWERTY ─────────
            //keyMap['\t'] = new Rectangle(20, 66, 60, 40); // Tab (1.5칸)
            keyMap['q'] = keyMap['Q'] = new Rectangle(160, 57, 80, 40);
            keyMap['w'] = keyMap['W'] = new Rectangle(254, 57, 80, 40);
            keyMap['e'] = keyMap['E'] = new Rectangle(348, 57, 80, 40);
            keyMap['r'] = keyMap['R'] = new Rectangle(442, 57, 80, 40);
            keyMap['t'] = keyMap['T'] = new Rectangle(536, 57, 80, 40);   
            keyMap['y'] = keyMap['Y'] = new Rectangle(630, 57, 80, 40);
            keyMap['u'] = keyMap['U'] = new Rectangle(724, 57, 80, 40);
            keyMap['i'] = keyMap['I'] = new Rectangle(818, 57, 80, 40);
            keyMap['o'] = keyMap['O'] = new Rectangle(912, 57, 80, 40);
            keyMap['p'] = keyMap['P'] = new Rectangle(1006, 57, 80, 40);
            keyMap['['] = keyMap['{'] = new Rectangle(1100, 57, 80, 40);
            keyMap[']'] = keyMap['}'] = new Rectangle(1194, 57, 80, 40);
            keyMap['\\'] = keyMap['|'] = new Rectangle(1288, 57, 100, 40);

            // ───────── Caps + ASDF ─────────
            // CapsLock은 생략(필요하면 넣으세요)
            keyMap['a'] = keyMap['A'] = new Rectangle(208, 105, 80, 40);
            keyMap['s'] = keyMap['S'] = new Rectangle(302, 105, 80, 40);
            keyMap['d'] = keyMap['D'] = new Rectangle(396, 105, 80, 40);
            keyMap['f'] = keyMap['F'] = new Rectangle(490, 105, 80, 40);
            keyMap['g'] = keyMap['G'] = new Rectangle(584, 105, 80, 40);
            keyMap['h'] = keyMap['H'] = new Rectangle(678, 105, 80, 40);
            keyMap['j'] = keyMap['J'] = new Rectangle(772, 105, 80, 40);
            keyMap['k'] = keyMap['K'] = new Rectangle(866, 105, 80, 40);
            keyMap['l'] = keyMap['L'] = new Rectangle(960, 105, 80, 40);
            keyMap[';'] = keyMap[':'] = new Rectangle(1054, 105, 80, 40);
            keyMap['\''] = keyMap['"'] = new Rectangle(1148, 105, 80, 40);
            keyMap['\n'] = new Rectangle(1242, 105, 160, 40); // Enter(2.5칸)

            // ───────── Shift + ZXCV ─────────
            // 왼쪽 Shift 생략
            keyMap['z'] = keyMap['Z'] = new Rectangle(252, 152, 80, 40);
            keyMap['x'] = keyMap['X'] = new Rectangle(346, 152, 80, 40);
            keyMap['c'] = keyMap['C'] = new Rectangle(440, 152, 80, 40);
            keyMap['v'] = keyMap['V'] = new Rectangle(534, 152, 80, 40);
            keyMap['b'] = keyMap['B'] = new Rectangle(628, 152, 80, 40);
            keyMap['n'] = keyMap['N'] = new Rectangle(722, 152, 80, 40);   
            keyMap['m'] = keyMap['M'] = new Rectangle(816, 152, 80, 40);
            keyMap[','] = keyMap['<'] = new Rectangle(910, 152, 80, 40);
            keyMap['.'] = keyMap['>'] = new Rectangle(1004, 152, 80, 40);
            keyMap['/'] = keyMap['?'] = new Rectangle(1098, 152, 80, 40);
            // 오른쪽 Shift 생략

            // ───────── Space 줄 ─────────
            keyMap[' '] = new Rectangle(392, 198, 552, 40); // SpaceBar (약 5칸 폭)
        }



        private void CodePracticeFo_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();

            if (code_line_num > 0)
            {
                table_fill(code_line_num);

                var first = 코드연습panel.GetControlFromPosition(0, 0) as SplitContainer;

                if (first != null && first.Panel2.Controls[0] is RichTextBox rtb)
                {
                    rtb.ReadOnly = false;
                    rtb.TabStop = true;
                    this.ActiveControl = rtb;
                }
            }
        }



        private void table_fill(int line_num)
        {
            int startIndex = _totalLines - code_line_num;
            int chunk = Math.Min(_linesPerPage, line_num);


            for (int i = 0; i < chunk; i++)
            {
                int row = startIndex + i;
                코드연습panel.Controls.Add(table_entryfill(shareCodeSave.Code[row], row), 0, i);
            }


            code_line_num -= chunk;
        }

        private SplitContainer table_entryfill(string code, int table_num)
        {
            var split = new SplitContainer
            {
                Dock = DockStyle.None,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Orientation = Orientation.Horizontal
            };
            split.Height = (int)Math.Ceiling(codeFont.GetHeight())*2 + 2;

            var rtbCode = new RichTextBox
            {
                Font = codeFont,
                Text = code,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.Horizontal,
                TabStop = false,
                ShortcutsEnabled = false,
                Margin = new Padding(0),
                WordWrap = false,
                Multiline = false,
                Dock = DockStyle.Bottom,
            };
            rtbCode.Width = split.Panel1.Width;
            rtbCode.Height = (int)Math.Ceiling(codeFont.GetHeight()) + 1;

            var rtbInput = new RichTextBox
            {
                Font = codeFont,
                WordWrap = false,
                Tag = Tuple.Create(table_num, code),
                BorderStyle = BorderStyle.None,
                BackColor = SystemColors.Window,
                ReadOnly = true,
                TabStop = false,
                SelectionCharOffset = 0,
                ScrollBars = RichTextBoxScrollBars.Horizontal,
                ZoomFactor = 1.0f,
                LanguageOption = 0,
                MaxLength = code.Length,
                Multiline = false,
                Dock = DockStyle.Top,
            };
            rtbInput.Width = split.Panel2.Width;
            rtbInput.Height = (int)Math.Ceiling(codeFont.GetHeight()) + 1;

            split.Panel1.Padding = Padding.Empty;
            split.Panel2.Padding = Padding.Empty;

            rtbInput.KeyPress += rtbInput_KeyPress;
            rtbInput.TextChanged += rtbInput_TextChanged;

            split.Panel1.Controls.Add(rtbCode);
            CenterVertically(rtbCode, split.Panel1);
            split.Panel2.Controls.Add(rtbInput);
            CenterVertically(rtbInput, split.Panel2);

            return split;
        }

        private void CenterVertically(Control child, Control parent)
        {
            int newY = (parent.Height - child.Height) / 2;
            child.Location = new Point(child.Location.X, newY);
        }


        private void rtbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_startTime == null) _startTime = DateTime.Now;
        }


        private void FocusNextInputBox(int nextTableNum)
        {
            if (nextTableNum % _linesPerPage == 0 && code_line_num > 0)
            {
                코드연습panel.Controls.Clear();
                table_fill(code_line_num);
            }

            var ctrl = 코드연습panel.GetControlFromPosition(0, nextTableNum);
            var split = 코드연습panel.Controls.OfType<SplitContainer>().FirstOrDefault(s => s.Panel2.Controls.OfType<RichTextBox>().Any(r => ((Tuple<int, string>)r.Tag).Item1 == nextTableNum));
            if (split != null)
            {
                var rtb = split.Panel2.Controls.OfType<RichTextBox>().FirstOrDefault(r => ((Tuple<int, string>)r.Tag).Item1 == nextTableNum);
                if (rtb != null)
                {
                    rtb.ReadOnly = false;
                    rtb.TabStop = true;
                    rtb.Focus();

                    // ❷ 새 줄 첫 글자 하이라이트
                    string nextLineCode = ((Tuple<int, string>)rtb.Tag).Item2;
                    if (!string.IsNullOrEmpty(nextLineCode))
                        HighlightKey(nextLineCode[0]);
                }
            }
        }

        private void ShowResultAndFinish()
        {
            timer1.Stop();

            using (var dlg = new Form())
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.ClientSize = new Size(280, 150);
                dlg.Text = "완료";
                dlg.ControlBox = false;

                dlg.AcceptButton = null;
                dlg.KeyPreview = true;

                // ★ 여기서 Enter 완전히 차단
                dlg.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                };

                var lbl = new Label
                {
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = $"🎉 연습이 끝났습니다!\n\n타수  : {타수TB.Text}\n정확도: {정확도TB.Text}"
                };

                var btn = new Button
                {
                    Dock = DockStyle.Bottom,
                    Height = 34,
                    Text = "확 인",
                    TabStop = false
                };
                btn.Click += (_, __) => dlg.DialogResult = DialogResult.OK;

                dlg.Controls.Add(lbl);
                dlg.Controls.Add(btn);

                dlg.ShowDialog(this);
            }

            DataSent?.Invoke(this, new CodePracticeResult(int.Parse(타수TB.Text.Replace(" 타/분", "").Trim()), (int)Math.Round(double.Parse(정확도TB.Text.Replace("%", "").Trim()))));

            Close();

        }



        private bool _finished = false;
        private void rtbInput_TextChanged(object sender, EventArgs e)
        {

            var rtb = (RichTextBox)sender;
            var tag = (Tuple<int, string>)rtb.Tag;
            string code = tag.Item2;
            int newLen = rtb.TextLength;
            int oldLen = _prevLen.TryGetValue(rtb, out var pl) ? pl : 0;
            _prevLen[rtb] = newLen;
            _totalTyped += newLen - oldLen;

            int diff = newLen - oldLen;

            int caretPos = rtb.SelectionStart;
            if (diff < 0)
            {
                // 문자 삭제된 경우 현재 위치부터 끝까지 다시 색칠
                int start = caretPos;
                int len = Math.Min(code.Length, rtb.TextLength);

                for (int i = start; i < len; i++)
                {
                    rtb.SelectionStart = i;
                    rtb.SelectionLength = 1;

                    if (rtb.Text[i] == code[i])
                        rtb.SelectionColor = Color.Black;
                    else
                        rtb.SelectionColor = Color.Red;
                }

                int errorsThisLine = 0;
                for (int i = 0; i < rtb.TextLength && i < code.Length; i++)
                {
                    if (rtb.Text[i] != code[i])
                        errorsThisLine++;
                }

                int oldErrors = _prevErrors.TryGetValue(rtb, out var oe) ? oe : 0;
                _totalErrors = _totalErrors - oldErrors + errorsThisLine;
                _prevErrors[rtb] = errorsThisLine;
            }

            if (caretPos > 0 && caretPos <= code.Length)
            {
                int i = caretPos - 1;
                rtb.SuspendLayout();
                HideCaret(rtb.Handle);

                rtb.SelectionStart = i;
                rtb.SelectionLength = 1;

                if (rtb.Text[i] == code[i])
                {
                    rtb.SelectionColor = Color.Black;
                }
                else
                {
                    rtb.SelectionColor = Color.Red;
                    _totalErrors++;
                    // SystemSounds.Beep.Play();
                }

                rtb.SelectionStart = caretPos;
                rtb.SelectionLength = 0;

                ShowCaret(rtb.Handle);
                rtb.ResumeLayout();
            }

            UpdateStats(_totalErrors, _totalTyped);

            // 줄이 완성되면 최종 검사
            if (rtb.TextLength == code.Length)
            {
                HighlightKey('\n');

                int errorsThisLine = 0;
                for (int i = 0; i < code.Length; i++)
                {
                    if (rtb.Text[i] != code[i])
                        errorsThisLine++;
                }

                if (_doneRows.Add(tag.Item1))
                    _finishedLines++;

                _prevErrors[rtb] = errorsThisLine;
                rtb.ReadOnly = true;
                FocusNextInputBox(tag.Item1 + 1);

                if (!_finished && _finishedLines == _totalLines)
                {
                    _finished = true;
                    BeginInvoke((Action)ShowResultAndFinish);
                    return;
                }
                return;
            }

            // 타자가이드
            if (!_finished)                           // 아직 안 끝났으면
            {
                char next = GetNextExpectedChar(rtb, code);
                HighlightKey(next);
            }
        }


        char GetNextExpectedChar(RichTextBox rtb, string code)
        {
            int pos = rtb.TextLength;             // 다음에 입력해야 할 index
            if (pos >= code.Length) return '\0';  // 줄이 끝났으면 빈 문자
            return code[pos];
        }


        void HighlightKey(char c)
        {
            // ① 기존 강조 지우기
            if (kbOverlay.Image != null)
            {
                kbOverlay.Image.Dispose();
                kbOverlay.Image = null;
            }

            // ② 다음에 표시할 키가 없는 경우 그대로 종료
            if (c == '\0' || !keyMap.TryGetValue(c, out var rect))
                return;

            // ③ 새 비트맵과 그래픽 객체 준비
            Bitmap bmp = new Bitmap(kbOverlay.Width, kbOverlay.Height);
            Graphics g = Graphics.FromImage(bmp);
            Brush brush = new SolidBrush(Color.FromArgb(120, Color.Red)); // 투명 빨강

            // ④ 사각형 채우기
            g.FillRectangle(brush, rect);

            // ⑤ GDI 자원 해제
            brush.Dispose();
            g.Dispose();

            // ⑥ PictureBox 에 적용 (비트맵은 Dispose 하지 말아야 화면에 남아있음!)
            kbOverlay.Image = bmp;
        }




        private void UpdateStats(int totalErrors, int totalTyped)
        {
            double accuracy = totalTyped == 0 ? 100.0 : (totalTyped - totalErrors) * 100.0 / totalTyped;
            정확도TB.Text = $"{accuracy:0.0}%";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_startTime == null) return;
            double minutes = (DateTime.Now - _startTime.Value).TotalMinutes;
            if (minutes <= 0) return;

            double cpm = _totalTyped / minutes;
            타수TB.Text = $"{cpm:0} 타/분";
        }

        private void CodePracticeF_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private void 나가기_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
            this.Close();
        }
    }
}
