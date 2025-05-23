namespace client.RainForm
{
    partial class GameOver
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
            this.lbFinalScore = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.restartBtn = new Guna.UI2.WinForms.Guna2Button();
            this.exitBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lbFinalScore
            // 
            this.lbFinalScore.AutoSize = true;
            this.lbFinalScore.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.lbFinalScore.Location = new System.Drawing.Point(310, 199);
            this.lbFinalScore.Name = "lbFinalScore";
            this.lbFinalScore.Size = new System.Drawing.Size(100, 34);
            this.lbFinalScore.TabIndex = 0;
            this.lbFinalScore.Text = "점수: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼옛체", 20F);
            this.label2.Location = new System.Drawing.Point(276, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 57);
            this.label2.TabIndex = 1;
            this.label2.Text = "게임 오버";
            // 
            // restartBtn
            // 
            this.restartBtn.BackColor = System.Drawing.Color.White;
            this.restartBtn.BorderThickness = 1;
            this.restartBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.restartBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.restartBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.restartBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.restartBtn.FillColor = System.Drawing.Color.White;
            this.restartBtn.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.restartBtn.ForeColor = System.Drawing.Color.Black;
            this.restartBtn.Location = new System.Drawing.Point(286, 280);
            this.restartBtn.Margin = new System.Windows.Forms.Padding(5);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(273, 61);
            this.restartBtn.TabIndex = 4;
            this.restartBtn.Text = "다시 시작하기";
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.White;
            this.exitBtn.BorderThickness = 1;
            this.exitBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitBtn.FillColor = System.Drawing.Color.White;
            this.exitBtn.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.exitBtn.ForeColor = System.Drawing.Color.Black;
            this.exitBtn.Location = new System.Drawing.Point(286, 351);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(5);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(273, 55);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "끝내기";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbFinalScore);
            this.Name = "GameOver";
            this.Text = "GameOvercs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFinalScore;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button restartBtn;
        private Guna.UI2.WinForms.Guna2Button exitBtn;
    }
}