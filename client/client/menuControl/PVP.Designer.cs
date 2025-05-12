namespace client.menuControl
{
    partial class PVP
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnQuizStart = new Guna.UI2.WinForms.Guna2Button();
            this.btnFindDiff = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnQuizStart
            // 
            this.btnQuizStart.BackColor = System.Drawing.Color.White;
            this.btnQuizStart.BorderThickness = 1;
            this.btnQuizStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuizStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuizStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuizStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuizStart.FillColor = System.Drawing.Color.White;
            this.btnQuizStart.Font = new System.Drawing.Font("휴먼옛체", 16F);
            this.btnQuizStart.ForeColor = System.Drawing.Color.Black;
            this.btnQuizStart.Location = new System.Drawing.Point(119, 285);
            this.btnQuizStart.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnQuizStart.Name = "btnQuizStart";
            this.btnQuizStart.Size = new System.Drawing.Size(310, 109);
            this.btnQuizStart.TabIndex = 0;
            this.btnQuizStart.Text = "퀴즈 대결";
            this.btnQuizStart.Click += new System.EventHandler(this.btnQuizStart_Click);
            // 
            // btnFindDiff
            // 
            this.btnFindDiff.BackColor = System.Drawing.Color.White;
            this.btnFindDiff.BorderThickness = 1;
            this.btnFindDiff.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFindDiff.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFindDiff.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFindDiff.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFindDiff.FillColor = System.Drawing.Color.White;
            this.btnFindDiff.Font = new System.Drawing.Font("휴먼옛체", 16F);
            this.btnFindDiff.ForeColor = System.Drawing.Color.Black;
            this.btnFindDiff.Location = new System.Drawing.Point(541, 285);
            this.btnFindDiff.Margin = new System.Windows.Forms.Padding(5);
            this.btnFindDiff.Name = "btnFindDiff";
            this.btnFindDiff.Size = new System.Drawing.Size(357, 109);
            this.btnFindDiff.TabIndex = 1;
            this.btnFindDiff.Text = "틀린 코드 찾기";
            this.btnFindDiff.Click += new System.EventHandler(this.btnFindDiff_Click);
            // 
            // PVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnFindDiff);
            this.Controls.Add(this.btnQuizStart);
            this.Name = "PVP";
            this.Size = new System.Drawing.Size(1050, 690);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnQuizStart;
        private Guna.UI2.WinForms.Guna2Button btnFindDiff;
    }
}
