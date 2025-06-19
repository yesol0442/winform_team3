namespace client.HambugiGame
{
    partial class HambugiGameForm
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
            this.수입금TB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.음식만들기Bt = new System.Windows.Forms.Button();
            this.말풍선P = new System.Windows.Forms.Panel();
            this.actionBP = new System.Windows.Forms.FlowLayoutPanel();
            this.IngredientBP = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.orderQueue = new System.Windows.Forms.FlowLayoutPanel();
            this.orderPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.timerProgress = new System.Windows.Forms.Timer(this.components);
            this.orderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // 수입금TB
            // 
            this.수입금TB.AutoSize = true;
            this.수입금TB.BackColor = System.Drawing.Color.Transparent;
            this.수입금TB.Font = new System.Drawing.Font("휴먼매직체", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.수입금TB.Location = new System.Drawing.Point(646, 32);
            this.수입금TB.Name = "수입금TB";
            this.수입금TB.Size = new System.Drawing.Size(24, 24);
            this.수입금TB.TabIndex = 21;
            this.수입금TB.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("휴먼매직체", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(558, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "수입금: ";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(837, 18);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(637, 38);
            this.progressBar.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("휴먼매직체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(1157, 566);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 77);
            this.button1.TabIndex = 23;
            this.button1.Text = "블록 삭제";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 음식만들기Bt
            // 
            this.음식만들기Bt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.음식만들기Bt.BackColor = System.Drawing.Color.Transparent;
            this.음식만들기Bt.Enabled = false;
            this.음식만들기Bt.FlatAppearance.BorderSize = 0;
            this.음식만들기Bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.음식만들기Bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.음식만들기Bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.음식만들기Bt.Font = new System.Drawing.Font("휴먼매직체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.음식만들기Bt.Location = new System.Drawing.Point(1157, 649);
            this.음식만들기Bt.Name = "음식만들기Bt";
            this.음식만들기Bt.Size = new System.Drawing.Size(148, 77);
            this.음식만들기Bt.TabIndex = 22;
            this.음식만들기Bt.Text = "음식 만들기";
            this.음식만들기Bt.UseVisualStyleBackColor = false;
            this.음식만들기Bt.Click += new System.EventHandler(this.음식만들기Bt_Click);
            // 
            // 말풍선P
            // 
            this.말풍선P.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.말풍선P.BackColor = System.Drawing.Color.Transparent;
            this.말풍선P.Location = new System.Drawing.Point(1157, 144);
            this.말풍선P.Name = "말풍선P";
            this.말풍선P.Size = new System.Drawing.Size(317, 249);
            this.말풍선P.TabIndex = 18;
            this.말풍선P.Visible = false;
            // 
            // actionBP
            // 
            this.actionBP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionBP.BackColor = System.Drawing.Color.Transparent;
            this.actionBP.Location = new System.Drawing.Point(18, 746);
            this.actionBP.Name = "actionBP";
            this.actionBP.Size = new System.Drawing.Size(1456, 152);
            this.actionBP.TabIndex = 17;
            // 
            // IngredientBP
            // 
            this.IngredientBP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.IngredientBP.BackColor = System.Drawing.Color.Transparent;
            this.IngredientBP.Location = new System.Drawing.Point(272, 163);
            this.IngredientBP.Name = "IngredientBP";
            this.IngredientBP.Size = new System.Drawing.Size(300, 537);
            this.IngredientBP.TabIndex = 16;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(628, 154);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(503, 489);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // orderQueue
            // 
            this.orderQueue.BackColor = System.Drawing.Color.Transparent;
            this.orderQueue.Location = new System.Drawing.Point(18, 18);
            this.orderQueue.Name = "orderQueue";
            this.orderQueue.Size = new System.Drawing.Size(508, 100);
            this.orderQueue.TabIndex = 13;
            // 
            // orderPanel
            // 
            this.orderPanel.BackColor = System.Drawing.Color.Transparent;
            this.orderPanel.ColumnCount = 1;
            this.orderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orderPanel.Controls.Add(this.lblPrice, 0, 0);
            this.orderPanel.Controls.Add(this.lblComment, 0, 1);
            this.orderPanel.Location = new System.Drawing.Point(12, 270);
            this.orderPanel.Name = "orderPanel";
            this.orderPanel.RowCount = 2;
            this.orderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.orderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.orderPanel.Size = new System.Drawing.Size(255, 274);
            this.orderPanel.TabIndex = 24;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrice.Font = new System.Drawing.Font("휴먼매직체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPrice.Location = new System.Drawing.Point(3, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(249, 54);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "label2";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComment.Font = new System.Drawing.Font("휴먼매직체", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblComment.Location = new System.Drawing.Point(3, 54);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(249, 220);
            this.lblComment.TabIndex = 1;
            this.lblComment.Text = "label3";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HambugiGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 904);
            this.Controls.Add(this.orderPanel);
            this.Controls.Add(this.수입금TB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.음식만들기Bt);
            this.Controls.Add(this.말풍선P);
            this.Controls.Add(this.actionBP);
            this.Controls.Add(this.IngredientBP);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.orderQueue);
            this.Name = "HambugiGameForm";
            this.Text = "HambugiGameForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HambugiGameForm_FormClosed);
            this.Load += new System.EventHandler(this.HambugiGameForm_Load);
            this.orderPanel.ResumeLayout(false);
            this.orderPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label 수입금TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button 음식만들기Bt;
        private System.Windows.Forms.Panel 말풍선P;
        private System.Windows.Forms.FlowLayoutPanel actionBP;
        private System.Windows.Forms.FlowLayoutPanel IngredientBP;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel orderQueue;
        private System.Windows.Forms.TableLayoutPanel orderPanel;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Timer timerProgress;
    }
}