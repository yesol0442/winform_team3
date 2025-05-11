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
            this.btnQuizStart.Location = new System.Drawing.Point(97, 178);
            this.btnQuizStart.Name = "btnQuizStart";
            this.btnQuizStart.Size = new System.Drawing.Size(191, 68);
            this.btnQuizStart.TabIndex = 0;
            this.btnQuizStart.Text = "퀴즈 대결";
            this.btnQuizStart.Click += new System.EventHandler(this.btnQuizStart_Click);
            // 
            // PVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnQuizStart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PVP";
            this.Size = new System.Drawing.Size(646, 431);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnQuizStart;
    }
}
