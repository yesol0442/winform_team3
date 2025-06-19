namespace client.FindDifferForm
{
    partial class FindForm
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
            this.codeTxt = new System.Windows.Forms.RichTextBox();
            this.lbScore = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.lbNoti = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // codeTxt
            // 
            this.codeTxt.Font = new System.Drawing.Font("휴먼옛체", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.codeTxt.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.codeTxt.Location = new System.Drawing.Point(52, 62);
            this.codeTxt.Name = "codeTxt";
            this.codeTxt.ReadOnly = true;
            this.codeTxt.Size = new System.Drawing.Size(1208, 625);
            this.codeTxt.TabIndex = 0;
            this.codeTxt.Text = "";
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.lbScore.Location = new System.Drawing.Point(69, 17);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(117, 34);
            this.lbScore.TabIndex = 1;
            this.lbScore.Text = "점수: 0";
            this.lbScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Font = new System.Drawing.Font("휴먼옛체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbCount.Location = new System.Drawing.Point(1018, 16);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(177, 34);
            this.lbCount.TabIndex = 2;
            this.lbCount.Text = "남은 개수: ";
            // 
            // lbNoti
            // 
            this.lbNoti.AutoSize = true;
            this.lbNoti.Font = new System.Drawing.Font("휴먼옛체", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbNoti.Location = new System.Drawing.Point(487, 299);
            this.lbNoti.Name = "lbNoti";
            this.lbNoti.Size = new System.Drawing.Size(298, 102);
            this.lbNoti.TabIndex = 3;
            this.lbNoti.Text = "label1";
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 710);
            this.Controls.Add(this.lbNoti);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.codeTxt);
            this.Name = "FindForm";
            this.Text = "틀린  코드 찾기";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FindForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeTxt;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Label lbNoti;
    }
}