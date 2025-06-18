namespace client.BlockForm
{
    partial class BlockStart
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
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnTutorial = new Guna.UI2.WinForms.Guna2Button();
            this.btnStart = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BorderThickness = 1;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("휴먼옛체", 14F);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(504, 544);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(292, 72);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "끝내기";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTutorial
            // 
            this.btnTutorial.BorderThickness = 1;
            this.btnTutorial.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTutorial.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTutorial.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTutorial.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTutorial.FillColor = System.Drawing.Color.White;
            this.btnTutorial.Font = new System.Drawing.Font("휴먼옛체", 14F);
            this.btnTutorial.ForeColor = System.Drawing.Color.Black;
            this.btnTutorial.Location = new System.Drawing.Point(504, 448);
            this.btnTutorial.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnTutorial.Name = "btnTutorial";
            this.btnTutorial.Size = new System.Drawing.Size(292, 72);
            this.btnTutorial.TabIndex = 11;
            this.btnTutorial.Text = "게임방법";
            this.btnTutorial.Click += new System.EventHandler(this.btnTutorial_Click);
            // 
            // btnStart
            // 
            this.btnStart.BorderThickness = 1;
            this.btnStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStart.FillColor = System.Drawing.Color.White;
            this.btnStart.Font = new System.Drawing.Font("휴먼옛체", 14F);
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(504, 352);
            this.btnStart.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(292, 72);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "시작하기";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼옛체", 30F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(382, 176);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(517, 85);
            this.label1.TabIndex = 9;
            this.label1.Text = "블록　맞추기";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(892, 475);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 35);
            this.textBox1.TabIndex = 13;
            // 
            // BlockStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTutorial);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "BlockStart";
            this.Text = "BlockStart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Button btnTutorial;
        private Guna.UI2.WinForms.Guna2Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}