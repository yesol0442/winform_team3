namespace client.shareForm
{
    partial class code_add
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.텍스트파일가져오기btn = new System.Windows.Forms.Button();
            this.임시저장btn = new System.Windows.Forms.Button();
            this.코드설명textbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.코드내용TB = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.업로드btn = new System.Windows.Forms.Button();
            this.제목TB = new System.Windows.Forms.TextBox();
            this.난이도CB = new System.Windows.Forms.ComboBox();
            this.뒤로가기btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "제목:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "난이도 설정: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(14, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "코드 설명";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // 텍스트파일가져오기btn
            // 
            this.텍스트파일가져오기btn.Location = new System.Drawing.Point(17, 425);
            this.텍스트파일가져오기btn.Name = "텍스트파일가져오기btn";
            this.텍스트파일가져오기btn.Size = new System.Drawing.Size(353, 42);
            this.텍스트파일가져오기btn.TabIndex = 5;
            this.텍스트파일가져오기btn.Text = "텍스트 파일 가져오기";
            this.텍스트파일가져오기btn.UseVisualStyleBackColor = true;
            this.텍스트파일가져오기btn.Click += new System.EventHandler(this.텍스트파일가져오기btn_Click);
            // 
            // 임시저장btn
            // 
            this.임시저장btn.Location = new System.Drawing.Point(742, 425);
            this.임시저장btn.Name = "임시저장btn";
            this.임시저장btn.Size = new System.Drawing.Size(115, 42);
            this.임시저장btn.TabIndex = 6;
            this.임시저장btn.Text = "임시저장";
            this.임시저장btn.UseVisualStyleBackColor = true;
            this.임시저장btn.Click += new System.EventHandler(this.임시저장btn_Click);
            // 
            // 코드설명textbox
            // 
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
            this.코드설명textbox.Location = new System.Drawing.Point(16, 148);
            this.코드설명textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.코드설명textbox.Multiline = true;
            this.코드설명textbox.Name = "코드설명textbox";
            this.코드설명textbox.PlaceholderText = "";
            this.코드설명textbox.SelectedText = "";
            this.코드설명textbox.Size = new System.Drawing.Size(353, 269);
            this.코드설명textbox.TabIndex = 11;
            this.코드설명textbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // 코드내용TB
            // 
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
            this.코드내용TB.Location = new System.Drawing.Point(401, 34);
            this.코드내용TB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.코드내용TB.Multiline = true;
            this.코드내용TB.Name = "코드내용TB";
            this.코드내용TB.PlaceholderText = "";
            this.코드내용TB.SelectedText = "";
            this.코드내용TB.Size = new System.Drawing.Size(577, 383);
            this.코드내용TB.TabIndex = 14;
            this.코드내용TB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(397, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "코드 내용";
            // 
            // 업로드btn
            // 
            this.업로드btn.Location = new System.Drawing.Point(863, 425);
            this.업로드btn.Name = "업로드btn";
            this.업로드btn.Size = new System.Drawing.Size(115, 42);
            this.업로드btn.TabIndex = 16;
            this.업로드btn.Text = "업로드";
            this.업로드btn.UseVisualStyleBackColor = true;
            this.업로드btn.Click += new System.EventHandler(this.업로드btn_Click);
            // 
            // 제목TB
            // 
            this.제목TB.Location = new System.Drawing.Point(70, 29);
            this.제목TB.Name = "제목TB";
            this.제목TB.Size = new System.Drawing.Size(300, 28);
            this.제목TB.TabIndex = 17;
            // 
            // 난이도CB
            // 
            this.난이도CB.FormattingEnabled = true;
            this.난이도CB.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.난이도CB.Location = new System.Drawing.Point(133, 63);
            this.난이도CB.Name = "난이도CB";
            this.난이도CB.Size = new System.Drawing.Size(121, 27);
            this.난이도CB.TabIndex = 20;
            // 
            // 뒤로가기btn
            // 
            this.뒤로가기btn.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.뒤로가기btn.ForeColor = System.Drawing.Color.DimGray;
            this.뒤로가기btn.Location = new System.Drawing.Point(889, 3);
            this.뒤로가기btn.Name = "뒤로가기btn";
            this.뒤로가기btn.Size = new System.Drawing.Size(89, 27);
            this.뒤로가기btn.TabIndex = 21;
            this.뒤로가기btn.Text = "뒤로가기";
            this.뒤로가기btn.UseVisualStyleBackColor = true;
            this.뒤로가기btn.Click += new System.EventHandler(this.뒤로가기btn_Click);
            // 
            // code_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.뒤로가기btn);
            this.Controls.Add(this.난이도CB);
            this.Controls.Add(this.제목TB);
            this.Controls.Add(this.업로드btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.코드내용TB);
            this.Controls.Add(this.코드설명textbox);
            this.Controls.Add(this.임시저장btn);
            this.Controls.Add(this.텍스트파일가져오기btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "code_add";
            this.Size = new System.Drawing.Size(993, 528);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button 텍스트파일가져오기btn;
        private System.Windows.Forms.Button 임시저장btn;
        private Guna.UI2.WinForms.Guna2TextBox 코드설명textbox;
        private Guna.UI2.WinForms.Guna2TextBox 코드내용TB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button 업로드btn;
        private System.Windows.Forms.TextBox 제목TB;
        private System.Windows.Forms.ComboBox 난이도CB;
        private System.Windows.Forms.Button 뒤로가기btn;
    }
}
