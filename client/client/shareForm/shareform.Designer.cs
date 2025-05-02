namespace client.shareForm
{
    partial class shareform
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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.나가기 = new System.Windows.Forms.Button();
            this.코드추가btn = new System.Windows.Forms.Button();
            this.홈btn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // 나가기
            // 
            this.나가기.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.나가기.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.나가기.ForeColor = System.Drawing.SystemColors.ControlText;
            this.나가기.Location = new System.Drawing.Point(972, 13);
            this.나가기.Name = "나가기";
            this.나가기.Size = new System.Drawing.Size(33, 27);
            this.나가기.TabIndex = 3;
            this.나가기.Text = "X";
            this.나가기.UseVisualStyleBackColor = true;
            this.나가기.Click += new System.EventHandler(this.나가기_Click);
            // 
            // 코드추가btn
            // 
            this.코드추가btn.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.코드추가btn.Location = new System.Drawing.Point(856, 72);
            this.코드추가btn.Name = "코드추가btn";
            this.코드추가btn.Size = new System.Drawing.Size(138, 46);
            this.코드추가btn.TabIndex = 5;
            this.코드추가btn.Text = "코드 추가";
            this.코드추가btn.UseVisualStyleBackColor = true;
            // 
            // 홈btn
            // 
            this.홈btn.Font = new System.Drawing.Font("휴먼옛체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.홈btn.Location = new System.Drawing.Point(856, 134);
            this.홈btn.Name = "홈btn";
            this.홈btn.Size = new System.Drawing.Size(138, 46);
            this.홈btn.TabIndex = 6;
            this.홈btn.Text = "홈";
            this.홈btn.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(25, 72);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(812, 484);
            this.flowLayoutPanel1.TabIndex = 7;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // shareform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 586);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.홈btn);
            this.Controls.Add(this.코드추가btn);
            this.Controls.Add(this.나가기);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "shareform";
            this.Text = "shareform";
            this.Load += new System.EventHandler(this.shareform_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Button 나가기;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button 홈btn;
        private System.Windows.Forms.Button 코드추가btn;
    }
}