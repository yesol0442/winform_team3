namespace winform_team3.menuPanel
{
    partial class homeSc
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.shareBeebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::winform_team3.Properties.Resources.winkufairy;
            this.pictureBox1.InitialImage = global::winform_team3.Properties.Resources.winkufairy;
            this.pictureBox1.Location = new System.Drawing.Point(630, 211);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 317);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1023, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(0, 0);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // shareBeebtn
            // 
            this.shareBeebtn.BackColor = System.Drawing.Color.Transparent;
            this.shareBeebtn.FlatAppearance.BorderSize = 0;
            this.shareBeebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.shareBeebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.shareBeebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shareBeebtn.Location = new System.Drawing.Point(930, 192);
            this.shareBeebtn.Name = "shareBeebtn";
            this.shareBeebtn.Size = new System.Drawing.Size(204, 336);
            this.shareBeebtn.TabIndex = 2;
            this.shareBeebtn.UseVisualStyleBackColor = false;
            this.shareBeebtn.Click += new System.EventHandler(this.shareBeebtn_Click);
            this.shareBeebtn.MouseEnter += new System.EventHandler(this.shareBeebtn_MouseEnter);
            this.shareBeebtn.MouseLeave += new System.EventHandler(this.shareBeebtn_MouseLeave);
            // 
            // homeSc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.shareBeebtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "homeSc";
            this.Size = new System.Drawing.Size(1239, 583);
            this.Load += new System.EventHandler(this.homeSc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button shareBeebtn;
    }
}
