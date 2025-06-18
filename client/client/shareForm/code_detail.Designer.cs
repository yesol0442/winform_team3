namespace client.shareForm
{
    partial class code_detail
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
            this.코드설명textbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.제목lbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.닉네임lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.난이도lbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.가져오기btn = new System.Windows.Forms.Button();
            this.뒤로가기btn = new System.Windows.Forms.Button();
            this.코드내용TB = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // 코드설명textbox
            // 
            this.코드설명textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.코드설명textbox.AutoScroll = true;
            this.코드설명textbox.BackColor = System.Drawing.Color.LightGray;
            this.코드설명textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.코드설명textbox.DefaultText = "";
            this.코드설명textbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.코드설명textbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.코드설명textbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.코드설명textbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.코드설명textbox.FillColor = System.Drawing.Color.WhiteSmoke;
            this.코드설명textbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.코드설명textbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.코드설명textbox.ForeColor = System.Drawing.Color.DimGray;
            this.코드설명textbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.코드설명textbox.Location = new System.Drawing.Point(19, 448);
            this.코드설명textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.코드설명textbox.Multiline = true;
            this.코드설명textbox.Name = "코드설명textbox";
            this.코드설명textbox.PlaceholderText = "";
            this.코드설명textbox.ReadOnly = true;
            this.코드설명textbox.SelectedText = "";
            this.코드설명textbox.Size = new System.Drawing.Size(409, 310);
            this.코드설명textbox.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.제목lbl);
            this.panel1.Controls.Add(this.코드설명textbox);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.닉네임lbl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.난이도lbl);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 775);
            this.panel1.TabIndex = 11;
            // 
            // 제목lbl
            // 
            this.제목lbl.AutoSize = true;
            this.제목lbl.Font = new System.Drawing.Font("휴먼옛체", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.제목lbl.Location = new System.Drawing.Point(18, 64);
            this.제목lbl.Name = "제목lbl";
            this.제목lbl.Size = new System.Drawing.Size(64, 27);
            this.제목lbl.TabIndex = 4;
            this.제목lbl.Text = "제목";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(19, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(317, 310);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // 닉네임lbl
            // 
            this.닉네임lbl.AutoSize = true;
            this.닉네임lbl.Font = new System.Drawing.Font("휴먼옛체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.닉네임lbl.Location = new System.Drawing.Point(103, 10);
            this.닉네임lbl.Name = "닉네임lbl";
            this.닉네임lbl.Size = new System.Drawing.Size(77, 26);
            this.닉네임lbl.TabIndex = 2;
            this.닉네임lbl.Text = "label2";
            this.닉네임lbl.Click += new System.EventHandler(this.닉네임lbl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼옛체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "업로드: ";
            // 
            // 난이도lbl
            // 
            this.난이도lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.난이도lbl.AutoSize = true;
            this.난이도lbl.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.난이도lbl.Location = new System.Drawing.Point(17, 407);
            this.난이도lbl.Name = "난이도lbl";
            this.난이도lbl.Size = new System.Drawing.Size(114, 36);
            this.난이도lbl.TabIndex = 0;
            this.난이도lbl.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.가져오기btn);
            this.panel2.Controls.Add(this.뒤로가기btn);
            this.panel2.Controls.Add(this.코드내용TB);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(457, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(957, 775);
            this.panel2.TabIndex = 12;
            // 
            // 가져오기btn
            // 
            this.가져오기btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.가져오기btn.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.가져오기btn.Location = new System.Drawing.Point(803, 709);
            this.가져오기btn.Name = "가져오기btn";
            this.가져오기btn.Size = new System.Drawing.Size(138, 50);
            this.가져오기btn.TabIndex = 17;
            this.가져오기btn.Text = "가져오기";
            this.가져오기btn.UseVisualStyleBackColor = true;
            this.가져오기btn.Click += new System.EventHandler(this.가져오기btn_Click);
            // 
            // 뒤로가기btn
            // 
            this.뒤로가기btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.뒤로가기btn.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.뒤로가기btn.ForeColor = System.Drawing.Color.DimGray;
            this.뒤로가기btn.Location = new System.Drawing.Point(803, 10);
            this.뒤로가기btn.Name = "뒤로가기btn";
            this.뒤로가기btn.Size = new System.Drawing.Size(138, 46);
            this.뒤로가기btn.TabIndex = 13;
            this.뒤로가기btn.Text = "뒤로가기";
            this.뒤로가기btn.UseVisualStyleBackColor = true;
            this.뒤로가기btn.Click += new System.EventHandler(this.뒤로가기btn_Click);
            // 
            // 코드내용TB
            // 
            this.코드내용TB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.코드내용TB.AutoScroll = true;
            this.코드내용TB.BackColor = System.Drawing.Color.LightGray;
            this.코드내용TB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.코드내용TB.DefaultText = "";
            this.코드내용TB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.코드내용TB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.코드내용TB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.코드내용TB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.코드내용TB.FillColor = System.Drawing.Color.WhiteSmoke;
            this.코드내용TB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.코드내용TB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.코드내용TB.ForeColor = System.Drawing.Color.DimGray;
            this.코드내용TB.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.코드내용TB.Location = new System.Drawing.Point(18, 64);
            this.코드내용TB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.코드내용TB.Multiline = true;
            this.코드내용TB.Name = "코드내용TB";
            this.코드내용TB.PlaceholderText = "";
            this.코드내용TB.ReadOnly = true;
            this.코드내용TB.SelectedText = "";
            this.코드내용TB.Size = new System.Drawing.Size(923, 637);
            this.코드내용TB.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼옛체", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(13, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "코드 내용";
            // 
            // code_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "code_detail";
            this.Size = new System.Drawing.Size(1417, 782);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox 코드설명textbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label 닉네임lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label 난이도lbl;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2TextBox 코드내용TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button 뒤로가기btn;
        private System.Windows.Forms.Label 제목lbl;
        private System.Windows.Forms.Button 가져오기btn;
    }
}

