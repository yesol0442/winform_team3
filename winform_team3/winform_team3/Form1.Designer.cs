namespace winform_team3
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
            this.panelMenu = new System.Windows.Forms.TableLayoutPanel();
            this.wpbtn = new System.Windows.Forms.Button();
            this.tbbtn = new System.Windows.Forms.Button();
            this.wdbtn = new System.Windows.Forms.Button();
            this.csbtn = new System.Windows.Forms.Button();
            this.homebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pMain = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.ColumnCount = 5;
            this.panelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelMenu.Controls.Add(this.wpbtn, 0, 0);
            this.panelMenu.Controls.Add(this.tbbtn, 1, 0);
            this.panelMenu.Controls.Add(this.wdbtn, 2, 0);
            this.panelMenu.Controls.Add(this.csbtn, 3, 0);
            this.panelMenu.Controls.Add(this.homebtn, 4, 0);
            this.panelMenu.Location = new System.Drawing.Point(3, 3);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.RowCount = 1;
            this.panelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMenu.Size = new System.Drawing.Size(1219, 69);
            this.panelMenu.TabIndex = 1;
            // 
            // wpbtn
            // 
            this.wpbtn.BackColor = System.Drawing.Color.Transparent;
            this.wpbtn.FlatAppearance.BorderSize = 0;
            this.wpbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.wpbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.wpbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wpbtn.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.wpbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.wpbtn.Location = new System.Drawing.Point(3, 3);
            this.wpbtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.wpbtn.Name = "wpbtn";
            this.wpbtn.Size = new System.Drawing.Size(237, 61);
            this.wpbtn.TabIndex = 0;
            this.wpbtn.Text = "배경화면";
            this.wpbtn.UseVisualStyleBackColor = false;
            this.wpbtn.Click += new System.EventHandler(this.wpbtn_Click);
            // 
            // tbbtn
            // 
            this.tbbtn.BackColor = System.Drawing.Color.Transparent;
            this.tbbtn.FlatAppearance.BorderSize = 0;
            this.tbbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.tbbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.tbbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbbtn.Location = new System.Drawing.Point(246, 3);
            this.tbbtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tbbtn.Name = "tbbtn";
            this.tbbtn.Size = new System.Drawing.Size(237, 61);
            this.tbbtn.TabIndex = 1;
            this.tbbtn.Text = "작업표시줄";
            this.tbbtn.UseVisualStyleBackColor = false;
            this.tbbtn.Click += new System.EventHandler(this.tbbtn_Click);
            // 
            // wdbtn
            // 
            this.wdbtn.BackColor = System.Drawing.Color.Transparent;
            this.wdbtn.FlatAppearance.BorderSize = 0;
            this.wdbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.wdbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.wdbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wdbtn.Location = new System.Drawing.Point(489, 3);
            this.wdbtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.wdbtn.Name = "wdbtn";
            this.wdbtn.Size = new System.Drawing.Size(237, 61);
            this.wdbtn.TabIndex = 2;
            this.wdbtn.Text = "윈도우 창";
            this.wdbtn.UseVisualStyleBackColor = false;
            this.wdbtn.Click += new System.EventHandler(this.wdbtn_Click);
            // 
            // csbtn
            // 
            this.csbtn.BackColor = System.Drawing.Color.Transparent;
            this.csbtn.FlatAppearance.BorderSize = 0;
            this.csbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.csbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.csbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.csbtn.Location = new System.Drawing.Point(732, 3);
            this.csbtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.csbtn.Name = "csbtn";
            this.csbtn.Size = new System.Drawing.Size(237, 61);
            this.csbtn.TabIndex = 3;
            this.csbtn.Text = "마우스 커서";
            this.csbtn.UseVisualStyleBackColor = false;
            this.csbtn.Click += new System.EventHandler(this.csbtn_Click);
            // 
            // homebtn
            // 
            this.homebtn.BackColor = System.Drawing.Color.Transparent;
            this.homebtn.FlatAppearance.BorderSize = 0;
            this.homebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.homebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.homebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homebtn.Location = new System.Drawing.Point(975, 3);
            this.homebtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.homebtn.Name = "homebtn";
            this.homebtn.Size = new System.Drawing.Size(241, 61);
            this.homebtn.TabIndex = 4;
            this.homebtn.UseVisualStyleBackColor = false;
            this.homebtn.Click += new System.EventHandler(this.homebtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.ColumnCount = 1;
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel1.Controls.Add(this.panelMenu, 0, 0);
            this.panel1.Controls.Add(this.pMain, 0, 1);
            this.panel1.Location = new System.Drawing.Point(11, 9);
            this.panel1.Name = "panel1";
            this.panel1.RowCount = 2;
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.44578F));
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.55421F));
            this.panel1.Size = new System.Drawing.Size(1225, 664);
            this.panel1.TabIndex = 2;
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.Transparent;
            this.pMain.Location = new System.Drawing.Point(3, 75);
            this.pMain.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1219, 583);
            this.pMain.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1249, 677);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel panelMenu;
        private System.Windows.Forms.Button wpbtn;
        private System.Windows.Forms.Button tbbtn;
        private System.Windows.Forms.Button wdbtn;
        private System.Windows.Forms.Button csbtn;
        private System.Windows.Forms.Button homebtn;
        private System.Windows.Forms.TableLayoutPanel panel1;
        private System.Windows.Forms.Panel pMain;
    }
}

