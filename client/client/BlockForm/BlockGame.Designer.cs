namespace client.BlockForm
{
    partial class BlockGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.complete = new System.Windows.Forms.Label();
            this.lbl_q2 = new System.Windows.Forms.Label();
            this.lbl_blink = new System.Windows.Forms.Label();
            this.lbl_q1 = new System.Windows.Forms.Label();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.block5 = new System.Windows.Forms.Label();
            this.block3 = new System.Windows.Forms.Label();
            this.block4 = new System.Windows.Forms.Label();
            this.block2 = new System.Windows.Forms.Label();
            this.block1 = new System.Windows.Forms.Label();
            this.txt_answer = new System.Windows.Forms.TextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timer_next = new System.Windows.Forms.Timer(this.components);
            this.timer_result = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // complete
            // 
            this.complete.AutoSize = true;
            this.complete.BackColor = System.Drawing.Color.White;
            this.complete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.complete.Font = new System.Drawing.Font("굴림", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.complete.ForeColor = System.Drawing.Color.ForestGreen;
            this.complete.Location = new System.Drawing.Point(75, 296);
            this.complete.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.complete.Name = "complete";
            this.complete.Size = new System.Drawing.Size(509, 98);
            this.complete.TabIndex = 39;
            this.complete.Text = "Complete!";
            // 
            // lbl_q2
            // 
            this.lbl_q2.BackColor = System.Drawing.Color.White;
            this.lbl_q2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_q2.Location = new System.Drawing.Point(674, 454);
            this.lbl_q2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_q2.Name = "lbl_q2";
            this.lbl_q2.Size = new System.Drawing.Size(605, 223);
            this.lbl_q2.TabIndex = 38;
            this.lbl_q2.Text = "\r\n    cout << \"최댓값: \" << max << endl;\r\n    return 0;\r\n}";
            // 
            // lbl_blink
            // 
            this.lbl_blink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_blink.ForeColor = System.Drawing.Color.Red;
            this.lbl_blink.Location = new System.Drawing.Point(674, 262);
            this.lbl_blink.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_blink.Name = "lbl_blink";
            this.lbl_blink.Size = new System.Drawing.Size(605, 191);
            this.lbl_blink.TabIndex = 37;
            this.lbl_blink.Text = "    \r\n    // 빈칸 1\r\n    // 빈칸 2\r\n        // 빈칸 3\r\n    //빈칸 4\r\n//빈칸 5";
            // 
            // lbl_q1
            // 
            this.lbl_q1.BackColor = System.Drawing.Color.White;
            this.lbl_q1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_q1.Location = new System.Drawing.Point(674, 43);
            this.lbl_q1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_q1.Name = "lbl_q1";
            this.lbl_q1.Size = new System.Drawing.Size(605, 218);
            this.lbl_q1.TabIndex = 36;
            this.lbl_q1.Text = "\r\n#include <iostream>\r\nusing namespace std;\r\n\r\nint main() {\r\n    int numbers[] = " +
    "{3, 7, 2, 9, 5};\r\n    int max = numbers[0];";
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Font = new System.Drawing.Font("휴먼옛체", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_timer.ForeColor = System.Drawing.Color.Blue;
            this.lbl_timer.Location = new System.Drawing.Point(50, 43);
            this.lbl_timer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(49, 51);
            this.lbl_timer.TabIndex = 35;
            this.lbl_timer.Text = "0";
            // 
            // block5
            // 
            this.block5.AutoSize = true;
            this.block5.BackColor = System.Drawing.Color.White;
            this.block5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.block5.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.block5.Location = new System.Drawing.Point(184, 536);
            this.block5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.block5.Name = "block5";
            this.block5.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.block5.Size = new System.Drawing.Size(40, 41);
            this.block5.TabIndex = 34;
            this.block5.Text = "}";
            // 
            // block3
            // 
            this.block3.AutoSize = true;
            this.block3.BackColor = System.Drawing.Color.White;
            this.block3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.block3.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.block3.Location = new System.Drawing.Point(208, 371);
            this.block3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.block3.Name = "block3";
            this.block3.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.block3.Size = new System.Drawing.Size(319, 41);
            this.block3.TabIndex = 33;
            this.block3.Text = "reversed[len] = \'\\0\';";
            // 
            // block4
            // 
            this.block4.AutoSize = true;
            this.block4.BackColor = System.Drawing.Color.White;
            this.block4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.block4.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.block4.Location = new System.Drawing.Point(91, 454);
            this.block4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.block4.Name = "block4";
            this.block4.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.block4.Size = new System.Drawing.Size(40, 41);
            this.block4.TabIndex = 32;
            this.block4.Text = "{";
            // 
            // block2
            // 
            this.block2.AutoSize = true;
            this.block2.BackColor = System.Drawing.Color.White;
            this.block2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.block2.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.block2.Location = new System.Drawing.Point(114, 277);
            this.block2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.block2.Name = "block2";
            this.block2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.block2.Size = new System.Drawing.Size(430, 41);
            this.block2.TabIndex = 31;
            this.block2.Text = "reversed[len - 1 - i] = str[i];";
            // 
            // block1
            // 
            this.block1.AutoSize = true;
            this.block1.BackColor = System.Drawing.Color.White;
            this.block1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.block1.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.block1.Location = new System.Drawing.Point(60, 181);
            this.block1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.block1.Name = "block1";
            this.block1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.block1.Size = new System.Drawing.Size(441, 41);
            this.block1.TabIndex = 30;
            this.block1.Text = "for (int i = len - 1; i >= 0; i--)";
            // 
            // txt_answer
            // 
            this.txt_answer.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_answer.Location = new System.Drawing.Point(36, 630);
            this.txt_answer.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txt_answer.Name = "txt_answer";
            this.txt_answer.Size = new System.Drawing.Size(584, 44);
            this.txt_answer.TabIndex = 29;
            this.txt_answer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_answer_KeyDown);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(650, 0);
            this.splitter2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(650, 720);
            this.splitter2.TabIndex = 28;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(650, 720);
            this.splitter1.TabIndex = 27;
            this.splitter1.TabStop = false;
            // 
            // timer_next
            // 
            this.timer_next.Interval = 1000;
            this.timer_next.Tick += new System.EventHandler(this.timer_next_Tick);
            // 
            // timer_result
            // 
            this.timer_result.Interval = 1000;
            this.timer_result.Tick += new System.EventHandler(this.timer_result_Tick);
            // 
            // BlockGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.complete);
            this.Controls.Add(this.lbl_q2);
            this.Controls.Add(this.lbl_blink);
            this.Controls.Add(this.lbl_q1);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.block5);
            this.Controls.Add(this.block3);
            this.Controls.Add(this.block4);
            this.Controls.Add(this.block2);
            this.Controls.Add(this.block1);
            this.Controls.Add(this.txt_answer);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "BlockGame";
            this.Text = "BlockGame";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BlockGame_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label complete;
        private System.Windows.Forms.Label lbl_q2;
        private System.Windows.Forms.Label lbl_blink;
        private System.Windows.Forms.Label lbl_q1;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Label block5;
        private System.Windows.Forms.Label block3;
        private System.Windows.Forms.Label block4;
        private System.Windows.Forms.Label block2;
        private System.Windows.Forms.Label block1;
        private System.Windows.Forms.TextBox txt_answer;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Timer timer_next;
        private System.Windows.Forms.Timer timer_result;
    }
}