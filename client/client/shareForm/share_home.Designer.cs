namespace client.shareForm
{
    partial class share_home
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
            this.사용자이름lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.뒤로가기btn = new System.Windows.Forms.Button();
            this.삭제btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 사용자이름lbl
            // 
            this.사용자이름lbl.AutoSize = true;
            this.사용자이름lbl.Font = new System.Drawing.Font("휴먼옛체", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.사용자이름lbl.Location = new System.Drawing.Point(12, 40);
            this.사용자이름lbl.Name = "사용자이름lbl";
            this.사용자이름lbl.Size = new System.Drawing.Size(69, 30);
            this.사용자이름lbl.TabIndex = 1;
            this.사용자이름lbl.Text = "나의";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼옛체", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "코드 공유함";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 171);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(955, 329);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // 뒤로가기btn
            // 
            this.뒤로가기btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.뒤로가기btn.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.뒤로가기btn.ForeColor = System.Drawing.Color.DimGray;
            this.뒤로가기btn.Location = new System.Drawing.Point(843, 13);
            this.뒤로가기btn.Name = "뒤로가기btn";
            this.뒤로가기btn.Size = new System.Drawing.Size(131, 47);
            this.뒤로가기btn.TabIndex = 15;
            this.뒤로가기btn.Text = "뒤로가기";
            this.뒤로가기btn.UseVisualStyleBackColor = true;
            this.뒤로가기btn.Click += new System.EventHandler(this.뒤로가기btn_Click);
            // 
            // 삭제btn
            // 
            this.삭제btn.Enabled = false;
            this.삭제btn.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.삭제btn.ForeColor = System.Drawing.Color.DimGray;
            this.삭제btn.Location = new System.Drawing.Point(17, 118);
            this.삭제btn.Name = "삭제btn";
            this.삭제btn.Size = new System.Drawing.Size(131, 47);
            this.삭제btn.TabIndex = 16;
            this.삭제btn.Text = "삭제하기";
            this.삭제btn.UseVisualStyleBackColor = true;
            this.삭제btn.Click += new System.EventHandler(this.삭제btn_Click);
            // 
            // share_home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.삭제btn);
            this.Controls.Add(this.뒤로가기btn);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.사용자이름lbl);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "share_home";
            this.Size = new System.Drawing.Size(993, 528);
            this.Load += new System.EventHandler(this.share_home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label 사용자이름lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button 뒤로가기btn;
        private System.Windows.Forms.Button 삭제btn;
    }
}
