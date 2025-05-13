namespace client
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.나가기 = new System.Windows.Forms.Button();
            this.내림 = new System.Windows.Forms.Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btn홈 = new Guna.UI2.WinForms.Guna2Button();
            this.btn코드연습 = new Guna.UI2.WinForms.Guna2Button();
            this.btnPVP = new Guna.UI2.WinForms.Guna2Button();
            this.btn미니게임 = new Guna.UI2.WinForms.Guna2Button();
            this.btn환경설정 = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.나가기.Location = new System.Drawing.Point(1264, 17);
            this.나가기.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.나가기.Name = "나가기";
            this.나가기.Size = new System.Drawing.Size(43, 36);
            this.나가기.TabIndex = 0;
            this.나가기.Text = "X";
            this.나가기.UseVisualStyleBackColor = true;
            this.나가기.Click += new System.EventHandler(this.나가기_Click);
            // 
            // 내림
            // 
            this.내림.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.내림.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.내림.Location = new System.Drawing.Point(1218, 17);
            this.내림.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.내림.Name = "내림";
            this.내림.Size = new System.Drawing.Size(43, 36);
            this.내림.TabIndex = 1;
            this.내림.Text = "_";
            this.내림.UseVisualStyleBackColor = true;
            this.내림.Click += new System.EventHandler(this.내림_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Location = new System.Drawing.Point(240, 61);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 7;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.guna2Panel1.Size = new System.Drawing.Size(1049, 689);
            this.guna2Panel1.TabIndex = 2;
            // 
            // btn홈
            // 
            this.btn홈.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn홈.DisabledState.BorderColor = System.Drawing.SystemColors.Control;
            this.btn홈.DisabledState.CustomBorderColor = System.Drawing.SystemColors.Control;
            this.btn홈.DisabledState.FillColor = System.Drawing.SystemColors.Control;
            this.btn홈.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn홈.FillColor = System.Drawing.SystemColors.Control;
            this.btn홈.Font = new System.Drawing.Font("휴먼옛체", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn홈.ForeColor = System.Drawing.Color.DimGray;
            this.btn홈.HoverState.BorderColor = System.Drawing.SystemColors.Control;
            this.btn홈.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btn홈.Location = new System.Drawing.Point(4, 4);
            this.btn홈.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn홈.Name = "btn홈";
            this.btn홈.PressedColor = System.Drawing.SystemColors.Control;
            this.btn홈.Size = new System.Drawing.Size(212, 87);
            this.btn홈.TabIndex = 3;
            this.btn홈.Text = "홈";
            this.btn홈.Click += new System.EventHandler(this.홈_Click);
            // 
            // btn코드연습
            // 
            this.btn코드연습.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn코드연습.DisabledState.BorderColor = System.Drawing.SystemColors.Control;
            this.btn코드연습.DisabledState.CustomBorderColor = System.Drawing.SystemColors.Control;
            this.btn코드연습.DisabledState.FillColor = System.Drawing.SystemColors.Control;
            this.btn코드연습.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn코드연습.FillColor = System.Drawing.SystemColors.Control;
            this.btn코드연습.Font = new System.Drawing.Font("휴먼옛체", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn코드연습.ForeColor = System.Drawing.Color.DimGray;
            this.btn코드연습.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btn코드연습.Location = new System.Drawing.Point(4, 99);
            this.btn코드연습.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn코드연습.Name = "btn코드연습";
            this.btn코드연습.PressedColor = System.Drawing.SystemColors.Control;
            this.btn코드연습.Size = new System.Drawing.Size(212, 87);
            this.btn코드연습.TabIndex = 4;
            this.btn코드연습.Text = "코드연습";
            this.btn코드연습.Click += new System.EventHandler(this.코드연습_Click);
            // 
            // btnPVP
            // 
            this.btnPVP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPVP.DisabledState.BorderColor = System.Drawing.SystemColors.Control;
            this.btnPVP.DisabledState.CustomBorderColor = System.Drawing.SystemColors.Control;
            this.btnPVP.DisabledState.FillColor = System.Drawing.SystemColors.Control;
            this.btnPVP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPVP.FillColor = System.Drawing.SystemColors.Control;
            this.btnPVP.Font = new System.Drawing.Font("휴먼옛체", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPVP.ForeColor = System.Drawing.Color.DimGray;
            this.btnPVP.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnPVP.Location = new System.Drawing.Point(4, 194);
            this.btnPVP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPVP.Name = "btnPVP";
            this.btnPVP.PressedColor = System.Drawing.SystemColors.Control;
            this.btnPVP.Size = new System.Drawing.Size(212, 87);
            this.btnPVP.TabIndex = 5;
            this.btnPVP.Text = "PVP";
            this.btnPVP.Click += new System.EventHandler(this.PVP_Click);
            // 
            // btn미니게임
            // 
            this.btn미니게임.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn미니게임.DisabledState.BorderColor = System.Drawing.SystemColors.Control;
            this.btn미니게임.DisabledState.CustomBorderColor = System.Drawing.SystemColors.Control;
            this.btn미니게임.DisabledState.FillColor = System.Drawing.SystemColors.Control;
            this.btn미니게임.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn미니게임.FillColor = System.Drawing.SystemColors.Control;
            this.btn미니게임.Font = new System.Drawing.Font("휴먼옛체", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn미니게임.ForeColor = System.Drawing.Color.DimGray;
            this.btn미니게임.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btn미니게임.Location = new System.Drawing.Point(4, 289);
            this.btn미니게임.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn미니게임.Name = "btn미니게임";
            this.btn미니게임.PressedColor = System.Drawing.SystemColors.Control;
            this.btn미니게임.Size = new System.Drawing.Size(212, 87);
            this.btn미니게임.TabIndex = 6;
            this.btn미니게임.Text = "미니게임";
            this.btn미니게임.Click += new System.EventHandler(this.미니게임_Click);
            // 
            // btn환경설정
            // 
            this.btn환경설정.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn환경설정.DisabledState.BorderColor = System.Drawing.SystemColors.Control;
            this.btn환경설정.DisabledState.CustomBorderColor = System.Drawing.SystemColors.Control;
            this.btn환경설정.DisabledState.FillColor = System.Drawing.SystemColors.Control;
            this.btn환경설정.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn환경설정.FillColor = System.Drawing.SystemColors.Control;
            this.btn환경설정.Font = new System.Drawing.Font("휴먼옛체", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn환경설정.ForeColor = System.Drawing.Color.DimGray;
            this.btn환경설정.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btn환경설정.Location = new System.Drawing.Point(4, 384);
            this.btn환경설정.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn환경설정.Name = "btn환경설정";
            this.btn환경설정.PressedColor = System.Drawing.SystemColors.Control;
            this.btn환경설정.Size = new System.Drawing.Size(212, 88);
            this.btn환경설정.TabIndex = 7;
            this.btn환경설정.Text = "환경설정";
            this.btn환경설정.Click += new System.EventHandler(this.환경설정_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btn환경설정, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn미니게임, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn코드연습, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPVP, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn홈, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 147);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 476);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1322, 781);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.내림);
            this.Controls.Add(this.나가기);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Button 내림;
        private System.Windows.Forms.Button 나가기;
        private Guna.UI2.WinForms.Guna2Button btn홈;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btn환경설정;
        private Guna.UI2.WinForms.Guna2Button btn미니게임;
        private Guna.UI2.WinForms.Guna2Button btnPVP;
        private Guna.UI2.WinForms.Guna2Button btn코드연습;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

