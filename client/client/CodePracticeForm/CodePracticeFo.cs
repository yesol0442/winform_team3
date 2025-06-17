using client.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.CodePracticeForm
{
    public partial class CodePracticeFo : Form
    {
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


        public CodePracticeFo(ShareCodeSave scs)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            shareCodeSave = scs;
            code_line_num = scs.Code.Count;
            _totalLines = scs.Code.Count;
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
            int chunk = Math.Min(12, line_num);


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
            if (nextTableNum % 13 == 0 && code_line_num > 0)
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
            }
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
