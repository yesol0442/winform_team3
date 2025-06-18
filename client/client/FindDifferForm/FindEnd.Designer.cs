namespace client.FindDifferForm
{
    partial class FindEnd
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
            this.lbResult = new System.Windows.Forms.Label();
            this.btnEnd = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼옛체", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(260, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "게임 종료";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("휴먼옛체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResult.Location = new System.Drawing.Point(343, 195);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(100, 34);
            this.lbResult.TabIndex = 1;
            this.lbResult.Text = "label2";
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
            this.btnEnd.Location = new System.Drawing.Point(298, 365);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(5);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(200, 53);
            this.btnEnd.TabIndex = 7;
            this.btnEnd.Text = "나가기";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // FindEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.label1);
            this.Name = "FindEnd";
            this.Text = "FindEnd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbResult;
        private Guna.UI2.WinForms.Guna2Button btnEnd;
    }
}