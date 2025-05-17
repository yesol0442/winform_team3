namespace client.shareForm
{
    partial class share_base
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.코드추가btn = new System.Windows.Forms.Button();
            this.홈btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(812, 484);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // 코드추가btn
            // 
            this.코드추가btn.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.코드추가btn.Location = new System.Drawing.Point(843, 26);
            this.코드추가btn.Name = "코드추가btn";
            this.코드추가btn.Size = new System.Drawing.Size(138, 46);
            this.코드추가btn.TabIndex = 9;
            this.코드추가btn.Text = "코드 추가";
            this.코드추가btn.UseVisualStyleBackColor = true;
            this.코드추가btn.Click += new System.EventHandler(this.코드추가btn_Click);
            // 
            // 홈btn
            // 
            this.홈btn.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.홈btn.Location = new System.Drawing.Point(843, 91);
            this.홈btn.Name = "홈btn";
            this.홈btn.Size = new System.Drawing.Size(138, 46);
            this.홈btn.TabIndex = 10;
            this.홈btn.Text = "홈";
            this.홈btn.UseVisualStyleBackColor = true;
            this.홈btn.Click += new System.EventHandler(this.홈btn_Click);
            // 
            // share_base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.홈btn);
            this.Controls.Add(this.코드추가btn);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "share_base";
            this.Size = new System.Drawing.Size(993, 528);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button 코드추가btn;
        private System.Windows.Forms.Button 홈btn;
    }
}
