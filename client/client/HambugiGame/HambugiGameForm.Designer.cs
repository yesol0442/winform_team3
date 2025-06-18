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
            this.orderQueue = new System.Windows.Forms.FlowLayoutPanel();
            this.orderPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.IngredientBP = new System.Windows.Forms.FlowLayoutPanel();
            this.actionBP = new System.Windows.Forms.FlowLayoutPanel();
            this.말풍선P = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.수입금 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // orderQueue
            // 
            this.orderQueue.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.orderQueue.Location = new System.Drawing.Point(12, 12);
            this.orderQueue.Name = "orderQueue";
            this.orderQueue.Size = new System.Drawing.Size(493, 100);
            this.orderQueue.TabIndex = 0;
            // 
            // orderPanel
            // 
            this.orderPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.orderPanel.Location = new System.Drawing.Point(12, 131);
            this.orderPanel.Name = "orderPanel";
            this.orderPanel.Size = new System.Drawing.Size(222, 275);
            this.orderPanel.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(530, 67);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(705, 601);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // IngredientBP
            // 
            this.IngredientBP.Location = new System.Drawing.Point(256, 131);
            this.IngredientBP.Name = "IngredientBP";
            this.IngredientBP.Size = new System.Drawing.Size(249, 537);
            this.IngredientBP.TabIndex = 3;
            // 
            // actionBP
            // 
            this.actionBP.Location = new System.Drawing.Point(207, 682);
            this.actionBP.Name = "actionBP";
            this.actionBP.Size = new System.Drawing.Size(1237, 189);
            this.actionBP.TabIndex = 4;
            // 
            // 말풍선P
            // 
            this.말풍선P.Location = new System.Drawing.Point(1320, 148);
            this.말풍선P.Name = "말풍선P";
            this.말풍선P.Size = new System.Drawing.Size(302, 207);
            this.말풍선P.TabIndex = 5;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(985, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(637, 38);
            this.progressBar1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼매직체", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(526, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "수입금: ";
            // 
            // 수입금
            // 
            this.수입금.AutoSize = true;
            this.수입금.Font = new System.Drawing.Font("휴먼매직체", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.수입금.Location = new System.Drawing.Point(614, 26);
            this.수입금.Name = "수입금";
            this.수입금.Size = new System.Drawing.Size(85, 24);
            this.수입금.TabIndex = 8;
            this.수입금.Text = "label2";
            // 
            // HambugiGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1634, 883);
            this.Controls.Add(this.수입금);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.말풍선P);
            this.Controls.Add(this.actionBP);
            this.Controls.Add(this.IngredientBP);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.orderPanel);
            this.Controls.Add(this.orderQueue);
            this.Name = "HambugiGameForm";
            this.Text = "HambugiGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel orderQueue;
        private System.Windows.Forms.Panel orderPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel IngredientBP;
        private System.Windows.Forms.FlowLayoutPanel actionBP;
        private System.Windows.Forms.Panel 말풍선P;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label 수입금;
    }
}