using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace client.CodePracticeForm
{
    public partial class CodePracticeF : Form
    {
        private readonly ShareCodeSave shareCodeSave;
        private DateTime? _startTime = null;


        private readonly Dictionary<RichTextBox, int> _prevLen = new Dictionary<RichTextBox, int>();
        private readonly Dictionary<RichTextBox, int> _prevErrors = new Dictionary<RichTextBox, int>();

        private readonly int _totalLines;
        private int _finishedLines = 0;
        private readonly HashSet<int> _doneRows = new HashSet<int>();

        private int _totalTyped = 0;
        private int _totalErrors = 0;

        private int code_line_num = 0;

        private Font codeFont = new Font("굴림체", 12f, FontStyle.Regular, GraphicsUnit.Pixel);


        public CodePracticeF(ShareCodeSave scs)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            shareCodeSave = scs;
            code_line_num = scs.Code.Count;
            _totalLines = scs.Code.Count;
        }

        private void CodePracticeF_Load(object sender, EventArgs e)
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
                    rtb.Focus();
                }
            }
        }

        private void 내림_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void 나가기_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
            Close();
        }


        private void table_fill(int line_num)
        {
            int startIndex = _totalLines - code_line_num;
            int chunk = Math.Min(13, line_num);


            for (int i = 0; i < chunk; i++)
            {
                int row = startIndex + i;
                코드연습panel.Controls.Add(table_entryfill(shareCodeSave.Code[row], row), 0, i);
            }


            code_line_num -= chunk;
        }

        private SplitContainer table_entryfill(string code, int table_num)
        {
            var split = new SplitContainer {
                Dock = DockStyle.None,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Orientation = Orientation.Horizontal 
            };

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
                Dock = DockStyle.None,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
            };
            rtbCode.Width = split.Panel1.Width;
            rtbCode.Height = (int)Math.Ceiling(codeFont.GetHeight()) + 2;

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
                Dock = DockStyle.None,
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
            };
            rtbInput.Width = split.Panel2.Width;
            rtbInput.Height = (int)Math.Ceiling(codeFont.GetHeight()) + 2;

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
            if (nextTableNum % 13 ==0 && code_line_num > 0)
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

            MessageBox.Show($"🎉 연습이 끝났습니다!\n\n타수  : {타수TB.Text} \n정확도: {정확도TB.Text}",
                            "완료", MessageBoxButtons.OK);
            Close();
        }


        private void rtbInput_TextChanged(object sender, EventArgs e)
        {
            var rtb = (RichTextBox)sender;
            var tag = (Tuple<int, string>)rtb.Tag;
            string code = tag.Item2;

            int newLen = rtb.TextLength;
            int oldLen = _prevLen.TryGetValue(rtb, out var pl) ? pl : 0;
            _prevLen[rtb] = newLen;
            _totalTyped += newLen - oldLen;

            int errorsThisLine = 0;
            int compareLen = Math.Min(code.Length, newLen);
            rtb.SuspendLayout();
            for (int i = 0; i < compareLen; i++)
            {
                rtb.Select(i, 1);
                if (rtb.Text[i] == code[i])
                    rtb.SelectionColor = Color.Black;
                else
                {
                    rtb.SelectionColor = Color.Red;
                    errorsThisLine++;
                    SystemSounds.Beep.Play();
                }
            }
            rtb.Select(rtb.TextLength, 0);
            rtb.ResumeLayout();

            int oldErrors = _prevErrors.TryGetValue(rtb, out var oe) ? oe : 0;
            _totalErrors = _totalErrors - oldErrors + errorsThisLine;
            _prevErrors[rtb] = errorsThisLine;

            UpdateStats(_totalErrors, _totalTyped);

            if (rtb.TextLength == code.Length)
            {
                if (_doneRows.Add(tag.Item1))
                    _finishedLines++;

                if (_finishedLines == _totalLines)
                {
                    ShowResultAndFinish();
                    return;
                }
                FocusNextInputBox(tag.Item1 + 1);
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
    }
}
