namespace client.menuControl
{
    partial class 미니게임
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
            this.rainBtn = new Guna.UI2.WinForms.Guna2Button();
            this.blockBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // rainBtn
            // 
            this.rainBtn.BackColor = System.Drawing.Color.White;
            this.rainBtn.BorderThickness = 1;
            this.rainBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.rainBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.rainBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.rainBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.rainBtn.FillColor = System.Drawing.Color.White;
            this.rainBtn.Font = new System.Drawing.Font("휴먼옛체", 16F);
            this.rainBtn.ForeColor = System.Drawing.Color.Black;
            this.rainBtn.Location = new System.Drawing.Point(102, 166);
            this.rainBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rainBtn.Name = "rainBtn";
            this.rainBtn.Size = new System.Drawing.Size(238, 82);
            this.rainBtn.TabIndex = 1;
            this.rainBtn.Text = "산성비";
            this.rainBtn.Click += new System.EventHandler(this.rainBtn_Click);
            // 
            // blockBtn
            // 
            this.blockBtn.BackColor = System.Drawing.Color.White;
            this.blockBtn.BorderThickness = 1;
            this.blockBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.blockBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.blockBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.blockBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.blockBtn.FillColor = System.Drawing.Color.White;
            this.blockBtn.Font = new System.Drawing.Font("휴먼옛체", 16F);
            this.blockBtn.ForeColor = System.Drawing.Color.Black;
            this.blockBtn.Location = new System.Drawing.Point(432, 166);
            this.blockBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.blockBtn.Name = "blockBtn";
            this.blockBtn.Size = new System.Drawing.Size(238, 82);
            this.blockBtn.TabIndex = 2;
            this.blockBtn.Text = "블록 맞추기";
            this.blockBtn.Click += new System.EventHandler(this.blockBtn_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.White;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("휴먼옛체", 16F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(262, 277);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(238, 82);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "코드 요리사";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // 미니게임
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.blockBtn);
            this.Controls.Add(this.rainBtn);
            this.Name = "미니게임";
            this.Size = new System.Drawing.Size(807, 517);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button rainBtn;
        private Guna.UI2.WinForms.Guna2Button blockBtn;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
