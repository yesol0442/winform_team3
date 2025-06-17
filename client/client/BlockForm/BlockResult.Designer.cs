namespace client.BlockForm
{
    partial class BlockResult
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
            this.label2 = new System.Windows.Forms.Label();
            this.result_current = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.result_best = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 16F);
            this.label2.Location = new System.Drawing.Point(151, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "소요시간 :";
            // 
            // result_current
            // 
            this.result_current.AutoSize = true;
            this.result_current.Font = new System.Drawing.Font("굴림", 16F);
            this.result_current.Location = new System.Drawing.Point(295, 76);
            this.result_current.Name = "result_current";
            this.result_current.Size = new System.Drawing.Size(55, 27);
            this.result_current.TabIndex = 8;
            this.result_current.Text = "0초";
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("굴림", 16F);
            this.btn_exit.Location = new System.Drawing.Point(156, 183);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(194, 57);
            this.btn_exit.TabIndex = 7;
            this.btn_exit.Text = "나가기";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 16F);
            this.label1.Location = new System.Drawing.Point(151, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "최고기록 :";
            // 
            // result_best
            // 
            this.result_best.AutoSize = true;
            this.result_best.Font = new System.Drawing.Font("굴림", 16F);
            this.result_best.Location = new System.Drawing.Point(295, 114);
            this.result_best.Name = "result_best";
            this.result_best.Size = new System.Drawing.Size(55, 27);
            this.result_best.TabIndex = 5;
            this.result_best.Text = "0초";
            // 
            // BlockResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 316);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.result_current);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result_best);
            this.Name = "BlockResult";
            this.Text = "BlockResult";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label result_current;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label result_best;
    }
}