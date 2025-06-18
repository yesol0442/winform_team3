namespace client.FindDifferForm
{
    partial class FindTutorial
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
            this.btnEnd = new Guna.UI2.WinForms.Guna2Button();
            this.btnGameStart = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEnd
            // 
            this.btnEnd.BorderThickness = 1;
            this.btnEnd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEnd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEnd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEnd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEnd.FillColor = System.Drawing.Color.White;
            this.btnEnd.Font = new System.Drawing.Font("휴먼옛체", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnd.ForeColor = System.Drawing.Color.Black;
            this.btnEnd.Location = new System.Drawing.Point(1048, 618);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(5);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(209, 69);
            this.btnEnd.TabIndex = 8;
            this.btnEnd.Text = "닫기";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnGameStart
            // 
            this.btnGameStart.BorderThickness = 1;
            this.btnGameStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGameStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGameStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGameStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGameStart.FillColor = System.Drawing.Color.White;
            this.btnGameStart.Font = new System.Drawing.Font("휴먼옛체", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGameStart.ForeColor = System.Drawing.Color.Black;
            this.btnGameStart.Location = new System.Drawing.Point(785, 618);
            this.btnGameStart.Margin = new System.Windows.Forms.Padding(5);
            this.btnGameStart.Name = "btnGameStart";
            this.btnGameStart.Size = new System.Drawing.Size(246, 69);
            this.btnGameStart.TabIndex = 9;
            this.btnGameStart.Text = "게임 시작하기";
            this.btnGameStart.Click += new System.EventHandler(this.btnGameStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼옛체", 20F);
            this.label1.Location = new System.Drawing.Point(59, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(572, 57);
            this.label1.TabIndex = 10;
            this.label1.Text = "퀴즈 대결 - 게임 방법";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(54, 168);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(16, 32, 16, 16);
            this.label3.Size = new System.Drawing.Size(1194, 418);
            this.label3.TabIndex = 11;
            this.label3.Text = "- 코드에 숨겨진 오류를 찾아 마우스로 클릭하세요.\r\n\r\n- 오류를 더 많이 맞히는 사람이 승리합니다.\r\n\r\n- 정답을 클릭하면 색으로 표시됩니다" +
    ".\r\n\r\n- 상대방의 정답도 실시간으로 확인할 수 있습니다.";
            // 
            // FindTutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGameStart);
            this.Controls.Add(this.btnEnd);
            this.Name = "FindTutorial";
            this.Text = "FindTutorial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnEnd;
        private Guna.UI2.WinForms.Guna2Button btnGameStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}