namespace client.RainForm
{
    partial class rainMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rainMain));
            this.inputTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbScore = new System.Windows.Forms.Label();
            this.StartTimer = new System.Windows.Forms.Timer(this.components);
            this.lbCount = new System.Windows.Forms.Label();
            this.lbLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputTxt
            // 
            this.inputTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inputTxt.DefaultText = "";
            this.inputTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.inputTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.inputTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.inputTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.inputTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.inputTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.inputTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.inputTxt.Location = new System.Drawing.Point(100, 369);
            this.inputTxt.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.inputTxt.Name = "inputTxt";
            this.inputTxt.PlaceholderText = "";
            this.inputTxt.SelectedText = "";
            this.inputTxt.Size = new System.Drawing.Size(160, 35);
            this.inputTxt.TabIndex = 0;
            this.inputTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTxt_KeyDown);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.lbScore.Location = new System.Drawing.Point(28, 28);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(117, 34);
            this.lbScore.TabIndex = 1;
            this.lbScore.Text = "점수: 0";
            // 
            // StartTimer
            // 
            this.StartTimer.Interval = 1000;
            this.StartTimer.Tick += new System.EventHandler(this.StartTimer_Tick);
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Font = new System.Drawing.Font("휴먼옛체", 36F);
            this.lbCount.ForeColor = System.Drawing.Color.White;
            this.lbCount.Location = new System.Drawing.Point(44, 169);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(298, 102);
            this.lbCount.TabIndex = 2;
            this.lbCount.Text = "label1";
            // 
            // lbLevel
            // 
            this.lbLevel.AutoSize = true;
            this.lbLevel.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.lbLevel.Location = new System.Drawing.Point(151, 28);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(117, 34);
            this.lbLevel.TabIndex = 3;
            this.lbLevel.Text = "레벨: 1";
            // 
            // rainMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(374, 429);
            this.Controls.Add(this.lbLevel);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.inputTxt);
            this.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "rainMain";
            this.Text = "산성비";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.rainMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox inputTxt;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Timer StartTimer;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Label lbLevel;
    }
}