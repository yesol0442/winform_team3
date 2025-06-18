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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnd = new Guna.UI2.WinForms.Guna2Button();
            this.btnGameStart = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼옛체", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(361, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "게임 방법";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼옛체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(64, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
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
            this.btnEnd.Location = new System.Drawing.Point(536, 544);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(5);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(200, 53);
            this.btnEnd.TabIndex = 8;
            this.btnEnd.Text = "나가기";
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
            this.btnGameStart.Location = new System.Drawing.Point(248, 544);
            this.btnGameStart.Margin = new System.Windows.Forms.Padding(5);
            this.btnGameStart.Name = "btnGameStart";
            this.btnGameStart.Size = new System.Drawing.Size(224, 53);
            this.btnGameStart.TabIndex = 9;
            this.btnGameStart.Text = "게임 시작하기";
            this.btnGameStart.Click += new System.EventHandler(this.btnGameStart_Click);
            // 
            // FindTutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 635);
            this.Controls.Add(this.btnGameStart);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FindTutorial";
            this.Text = "FindTutorial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnEnd;
        private Guna.UI2.WinForms.Guna2Button btnGameStart;
    }
}