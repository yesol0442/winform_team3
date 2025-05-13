namespace client.menuControl
{
    partial class 환경설정
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
            this.btn_modPicture = new System.Windows.Forms.Button();
            this.btn_modNickname = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSound = new System.Windows.Forms.Label();
            this.chkGuide = new System.Windows.Forms.CheckBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.togSound = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtNickname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Image = global::client.Properties.Resources.신지;
            this.pictureBox1.Location = new System.Drawing.Point(55, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 278);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_modPicture
            // 
            this.btn_modPicture.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.btn_modPicture.Location = new System.Drawing.Point(55, 350);
            this.btn_modPicture.Name = "btn_modPicture";
            this.btn_modPicture.Size = new System.Drawing.Size(289, 56);
            this.btn_modPicture.TabIndex = 1;
            this.btn_modPicture.Text = "프로필 사진 변경";
            this.btn_modPicture.UseVisualStyleBackColor = true;
            this.btn_modPicture.Click += new System.EventHandler(this.btn_modPicture_Click);
            // 
            // btn_modNickname
            // 
            this.btn_modNickname.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.btn_modNickname.Location = new System.Drawing.Point(385, 54);
            this.btn_modNickname.Name = "btn_modNickname";
            this.btn_modNickname.Size = new System.Drawing.Size(225, 59);
            this.btn_modNickname.TabIndex = 2;
            this.btn_modNickname.Text = "닉네임 변경";
            this.btn_modNickname.UseVisualStyleBackColor = true;
            this.btn_modNickname.Click += new System.EventHandler(this.btn_modNickname_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼옛체", 15F);
            this.label1.Location = new System.Drawing.Point(399, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "홍길동";
            // 
            // lblSound
            // 
            this.lblSound.AutoSize = true;
            this.lblSound.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.lblSound.Location = new System.Drawing.Point(400, 350);
            this.lblSound.Name = "lblSound";
            this.lblSound.Size = new System.Drawing.Size(111, 34);
            this.lblSound.TabIndex = 4;
            this.lblSound.Text = "사운드";
            // 
            // chkGuide
            // 
            this.chkGuide.AutoSize = true;
            this.chkGuide.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.chkGuide.Location = new System.Drawing.Point(692, 350);
            this.chkGuide.Name = "chkGuide";
            this.chkGuide.Size = new System.Drawing.Size(233, 38);
            this.chkGuide.TabIndex = 6;
            this.chkGuide.Text = " 타자 가이드";
            this.chkGuide.UseVisualStyleBackColor = true;
            this.chkGuide.CheckedChanged += new System.EventHandler(this.chkGuide_CheckedChanged);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "C",
            "C++"});
            this.cmbLanguage.Location = new System.Drawing.Point(758, 212);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(229, 42);
            this.cmbLanguage.TabIndex = 7;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.lblLanguage.Location = new System.Drawing.Point(677, 152);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(310, 34);
            this.lblLanguage.TabIndex = 8;
            this.lblLanguage.Text = "미니 게임 언어 설정";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("휴먼옛체", 12F);
            this.btnDelete.Location = new System.Drawing.Point(794, 558);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(193, 61);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "계정 삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // togSound
            // 
            this.togSound.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.togSound.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.togSound.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.togSound.CheckedState.InnerColor = System.Drawing.Color.White;
            this.togSound.Location = new System.Drawing.Point(536, 354);
            this.togSound.Name = "togSound";
            this.togSound.Size = new System.Drawing.Size(60, 30);
            this.togSound.TabIndex = 10;
            this.togSound.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.togSound.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.togSound.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.togSound.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.togSound.CheckedChanged += new System.EventHandler(this.togSound_CheckedChanged);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("굴림", 10F);
            this.txtId.Location = new System.Drawing.Point(435, 561);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(260, 38);
            this.txtId.TabIndex = 11;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("휴먼옛체", 10F);
            this.lblId.Location = new System.Drawing.Point(105, 564);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(311, 28);
            this.lblId.TabIndex = 12;
            this.lblId.Text = "아이디를 입력해주세요: ";
            // 
            // txtNickname
            // 
            this.txtNickname.Font = new System.Drawing.Font("휴먼옛체", 14F);
            this.txtNickname.Location = new System.Drawing.Point(385, 152);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(173, 50);
            this.txtNickname.TabIndex = 13;
            // 
            // 환경설정
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.togSound);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.chkGuide);
            this.Controls.Add(this.lblSound);
            this.Controls.Add(this.btn_modNickname);
            this.Controls.Add(this.btn_modPicture);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "환경설정";
            this.Size = new System.Drawing.Size(1049, 689);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_modPicture;
        private System.Windows.Forms.Button btn_modNickname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSound;
        private System.Windows.Forms.CheckBox chkGuide;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Button btnDelete;
        private Guna.UI2.WinForms.Guna2ToggleSwitch togSound;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtNickname;
    }
}
