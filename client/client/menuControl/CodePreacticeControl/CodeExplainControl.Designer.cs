namespace client.menuControl.CodePreacticeControl
{
    partial class CodeExplainControl
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
            this.난이도lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.뒤로가기btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.시작btn = new System.Windows.Forms.Button();
            this.제목label = new System.Windows.Forms.Label();
            this.코드설명textbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.업로더lbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 난이도lbl
            // 
            this.난이도lbl.AutoSize = true;
            this.난이도lbl.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.난이도lbl.ForeColor = System.Drawing.Color.Black;
            this.난이도lbl.Location = new System.Drawing.Point(16, 135);
            this.난이도lbl.Name = "난이도lbl";
            this.난이도lbl.Size = new System.Drawing.Size(149, 19);
            this.난이도lbl.TabIndex = 1;
            this.난이도lbl.Text = "난이도 표시 라벨";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "업로더:";
            // 
            // 뒤로가기btn
            // 
            this.뒤로가기btn.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.뒤로가기btn.ForeColor = System.Drawing.Color.DimGray;
            this.뒤로가기btn.Location = new System.Drawing.Point(284, 9);
            this.뒤로가기btn.Name = "뒤로가기btn";
            this.뒤로가기btn.Size = new System.Drawing.Size(89, 27);
            this.뒤로가기btn.TabIndex = 6;
            this.뒤로가기btn.Text = "뒤로가기";
            this.뒤로가기btn.UseVisualStyleBackColor = true;
            this.뒤로가기btn.Click += new System.EventHandler(this.뒤로가기btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "코드 설명:";
            // 
            // 시작btn
            // 
            this.시작btn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.시작btn.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.시작btn.ForeColor = System.Drawing.Color.Black;
            this.시작btn.Location = new System.Drawing.Point(128, 389);
            this.시작btn.Name = "시작btn";
            this.시작btn.Size = new System.Drawing.Size(137, 46);
            this.시작btn.TabIndex = 5;
            this.시작btn.Text = "시작";
            this.시작btn.UseVisualStyleBackColor = true;
            this.시작btn.Click += new System.EventHandler(this.시작btn_Click);
            // 
            // 제목label
            // 
            this.제목label.AutoSize = true;
            this.제목label.Font = new System.Drawing.Font("휴먼옛체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.제목label.Location = new System.Drawing.Point(18, 55);
            this.제목label.Name = "제목label";
            this.제목label.Size = new System.Drawing.Size(60, 26);
            this.제목label.TabIndex = 8;
            this.제목label.Text = "제목";
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
            this.코드설명textbox.Location = new System.Drawing.Point(20, 189);
            this.코드설명textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.코드설명textbox.Multiline = true;
            this.코드설명textbox.Name = "코드설명textbox";
            this.코드설명textbox.PlaceholderText = "";
            this.코드설명textbox.ReadOnly = true;
            this.코드설명textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.코드설명textbox.SelectedText = "";
            this.코드설명textbox.Size = new System.Drawing.Size(353, 192);
            this.코드설명textbox.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.업로더lbl);
            this.panel1.Controls.Add(this.코드설명textbox);
            this.panel1.Controls.Add(this.제목label);
            this.panel1.Controls.Add(this.시작btn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.뒤로가기btn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.난이도lbl);
            this.panel1.Location = new System.Drawing.Point(2, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 446);
            this.panel1.TabIndex = 8;
            // 
            // 업로더lbl
            // 
            this.업로더lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.업로더lbl.AutoSize = true;
            this.업로더lbl.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.업로더lbl.ForeColor = System.Drawing.Color.Black;
            this.업로더lbl.Location = new System.Drawing.Point(81, 105);
            this.업로더lbl.Name = "업로더lbl";
            this.업로더lbl.Size = new System.Drawing.Size(106, 19);
            this.업로더lbl.TabIndex = 10;
            this.업로더lbl.Text = "업로더 이름";
            // 
            // CodeExplainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panel1);
            this.Name = "CodeExplainControl";
            this.Size = new System.Drawing.Size(398, 511);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label 난이도lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button 뒤로가기btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button 시작btn;
        private System.Windows.Forms.Label 제목label;
        private Guna.UI2.WinForms.Guna2TextBox 코드설명textbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label 업로더lbl;
    }
}
