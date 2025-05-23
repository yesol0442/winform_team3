namespace client.FindDifferForm
{
    partial class FindReady
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
            this.gameStartBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // gameStartBtn
            // 
            this.gameStartBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gameStartBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gameStartBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gameStartBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gameStartBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gameStartBtn.ForeColor = System.Drawing.Color.White;
            this.gameStartBtn.Location = new System.Drawing.Point(331, 302);
            this.gameStartBtn.Name = "gameStartBtn";
            this.gameStartBtn.Size = new System.Drawing.Size(180, 45);
            this.gameStartBtn.TabIndex = 0;
            this.gameStartBtn.Text = "게임 시작";
            this.gameStartBtn.Click += new System.EventHandler(this.gameStartBtn_Click);
            // 
            // FindReady
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gameStartBtn);
            this.Name = "FindReady";
            this.Text = "FindReady";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button gameStartBtn;
    }
}