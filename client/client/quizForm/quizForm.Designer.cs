namespace client.quizForm
{
    partial class quizForm
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
            this.lbl_timer = new System.Windows.Forms.Label();
            this.playerAnswer4 = new System.Windows.Forms.Label();
            this.playerAnswer3 = new System.Windows.Forms.Label();
            this.playerAnswer2 = new System.Windows.Forms.Label();
            this.playerAnswer1 = new System.Windows.Forms.Label();
            this.player4Plus = new System.Windows.Forms.Label();
            this.player3Plus = new System.Windows.Forms.Label();
            this.player2Plus = new System.Windows.Forms.Label();
            this.player1Plus = new System.Windows.Forms.Label();
            this.playerScore4 = new System.Windows.Forms.Label();
            this.playerScore3 = new System.Windows.Forms.Label();
            this.playerScore2 = new System.Windows.Forms.Label();
            this.playerScore1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_sb4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pic_sb3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pic_sb2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pic_sb1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txt_answer = new Guna.UI2.WinForms.Guna2TextBox();
            this.playerPic4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.playerPic3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.playerPic2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.playerPic1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txt_question = new Guna.UI2.WinForms.Guna2TextBox();
            this.quizStartTimer = new System.Windows.Forms.Timer(this.components);
            this.answerReadyTimer = new System.Windows.Forms.Timer(this.components);
            this.pname1 = new System.Windows.Forms.Label();
            this.pname2 = new System.Windows.Forms.Label();
            this.pname3 = new System.Windows.Forms.Label();
            this.pname4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sb4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPic1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Font = new System.Drawing.Font("휴먼옛체", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_timer.ForeColor = System.Drawing.Color.Blue;
            this.lbl_timer.Location = new System.Drawing.Point(58, 59);
            this.lbl_timer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(83, 57);
            this.lbl_timer.TabIndex = 77;
            this.lbl_timer.Text = "10";
            // 
            // playerAnswer4
            // 
            this.playerAnswer4.BackColor = System.Drawing.Color.White;
            this.playerAnswer4.Font = new System.Drawing.Font("휴먼옛체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.playerAnswer4.Location = new System.Drawing.Point(1012, 211);
            this.playerAnswer4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.playerAnswer4.Name = "playerAnswer4";
            this.playerAnswer4.Size = new System.Drawing.Size(140, 42);
            this.playerAnswer4.TabIndex = 76;
            this.playerAnswer4.Text = "O";
            this.playerAnswer4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerAnswer3
            // 
            this.playerAnswer3.BackColor = System.Drawing.Color.White;
            this.playerAnswer3.Font = new System.Drawing.Font("휴먼옛체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.playerAnswer3.Location = new System.Drawing.Point(734, 211);
            this.playerAnswer3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.playerAnswer3.Name = "playerAnswer3";
            this.playerAnswer3.Size = new System.Drawing.Size(140, 42);
            this.playerAnswer3.TabIndex = 75;
            this.playerAnswer3.Text = "O";
            this.playerAnswer3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerAnswer2
            // 
            this.playerAnswer2.BackColor = System.Drawing.Color.White;
            this.playerAnswer2.Font = new System.Drawing.Font("휴먼옛체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.playerAnswer2.Location = new System.Drawing.Point(460, 211);
            this.playerAnswer2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.playerAnswer2.Name = "playerAnswer2";
            this.playerAnswer2.Size = new System.Drawing.Size(140, 42);
            this.playerAnswer2.TabIndex = 74;
            this.playerAnswer2.Text = "O";
            this.playerAnswer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerAnswer1
            // 
            this.playerAnswer1.BackColor = System.Drawing.Color.White;
            this.playerAnswer1.Font = new System.Drawing.Font("휴먼옛체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.playerAnswer1.Location = new System.Drawing.Point(184, 211);
            this.playerAnswer1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.playerAnswer1.Name = "playerAnswer1";
            this.playerAnswer1.Size = new System.Drawing.Size(140, 42);
            this.playerAnswer1.TabIndex = 73;
            this.playerAnswer1.Text = "O";
            this.playerAnswer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player4Plus
            // 
            this.player4Plus.BackColor = System.Drawing.Color.Transparent;
            this.player4Plus.Font = new System.Drawing.Font("휴먼옛체", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.player4Plus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.player4Plus.Location = new System.Drawing.Point(988, 382);
            this.player4Plus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.player4Plus.Name = "player4Plus";
            this.player4Plus.Size = new System.Drawing.Size(195, 56);
            this.player4Plus.TabIndex = 72;
            this.player4Plus.Text = "+10";
            this.player4Plus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player3Plus
            // 
            this.player3Plus.BackColor = System.Drawing.Color.Transparent;
            this.player3Plus.Font = new System.Drawing.Font("휴먼옛체", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.player3Plus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.player3Plus.Location = new System.Drawing.Point(712, 382);
            this.player3Plus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.player3Plus.Name = "player3Plus";
            this.player3Plus.Size = new System.Drawing.Size(195, 56);
            this.player3Plus.TabIndex = 71;
            this.player3Plus.Text = "+10";
            this.player3Plus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player2Plus
            // 
            this.player2Plus.BackColor = System.Drawing.Color.Transparent;
            this.player2Plus.Font = new System.Drawing.Font("휴먼옛체", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.player2Plus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.player2Plus.Location = new System.Drawing.Point(436, 382);
            this.player2Plus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.player2Plus.Name = "player2Plus";
            this.player2Plus.Size = new System.Drawing.Size(195, 56);
            this.player2Plus.TabIndex = 70;
            this.player2Plus.Text = "+10";
            this.player2Plus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player1Plus
            // 
            this.player1Plus.BackColor = System.Drawing.Color.Transparent;
            this.player1Plus.Font = new System.Drawing.Font("휴먼옛체", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.player1Plus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.player1Plus.Location = new System.Drawing.Point(159, 382);
            this.player1Plus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.player1Plus.Name = "player1Plus";
            this.player1Plus.Size = new System.Drawing.Size(195, 56);
            this.player1Plus.TabIndex = 69;
            this.player1Plus.Text = "+10";
            this.player1Plus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerScore4
            // 
            this.playerScore4.AutoSize = true;
            this.playerScore4.Font = new System.Drawing.Font("휴먼옛체", 11F);
            this.playerScore4.Location = new System.Drawing.Point(1076, 552);
            this.playerScore4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.playerScore4.Name = "playerScore4";
            this.playerScore4.Size = new System.Drawing.Size(30, 32);
            this.playerScore4.TabIndex = 68;
            this.playerScore4.Text = "0";
            // 
            // playerScore3
            // 
            this.playerScore3.AutoSize = true;
            this.playerScore3.Font = new System.Drawing.Font("휴먼옛체", 11F);
            this.playerScore3.Location = new System.Drawing.Point(800, 552);
            this.playerScore3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.playerScore3.Name = "playerScore3";
            this.playerScore3.Size = new System.Drawing.Size(30, 32);
            this.playerScore3.TabIndex = 67;
            this.playerScore3.Text = "0";
            // 
            // playerScore2
            // 
            this.playerScore2.AutoSize = true;
            this.playerScore2.Font = new System.Drawing.Font("휴먼옛체", 11F);
            this.playerScore2.Location = new System.Drawing.Point(523, 552);
            this.playerScore2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.playerScore2.Name = "playerScore2";
            this.playerScore2.Size = new System.Drawing.Size(30, 32);
            this.playerScore2.TabIndex = 66;
            this.playerScore2.Text = "0";
            // 
            // playerScore1
            // 
            this.playerScore1.AutoSize = true;
            this.playerScore1.Font = new System.Drawing.Font("휴먼옛체", 11F);
            this.playerScore1.Location = new System.Drawing.Point(247, 552);
            this.playerScore1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.playerScore1.Name = "playerScore1";
            this.playerScore1.Size = new System.Drawing.Size(30, 32);
            this.playerScore1.TabIndex = 65;
            this.playerScore1.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("휴먼옛체", 11F);
            this.label4.Location = new System.Drawing.Point(982, 552);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 32);
            this.label4.TabIndex = 64;
            this.label4.Text = "점수:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("휴먼옛체", 11F);
            this.label3.Location = new System.Drawing.Point(705, 552);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 32);
            this.label3.TabIndex = 63;
            this.label3.Text = "점수:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼옛체", 11F);
            this.label2.Location = new System.Drawing.Point(429, 552);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 32);
            this.label2.TabIndex = 62;
            this.label2.Text = "점수:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼옛체", 11F);
            this.label1.Location = new System.Drawing.Point(153, 552);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 32);
            this.label1.TabIndex = 61;
            this.label1.Text = "점수:";
            // 
            // pic_sb4
            // 
            this.pic_sb4.BackColor = System.Drawing.SystemColors.Control;
            this.pic_sb4.Image = global::client.Properties.Resources.speech_bubble;
            this.pic_sb4.ImageRotate = 0F;
            this.pic_sb4.Location = new System.Drawing.Point(1004, 184);
            this.pic_sb4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pic_sb4.Name = "pic_sb4";
            this.pic_sb4.Size = new System.Drawing.Size(162, 128);
            this.pic_sb4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_sb4.TabIndex = 56;
            this.pic_sb4.TabStop = false;
            // 
            // pic_sb3
            // 
            this.pic_sb3.Image = global::client.Properties.Resources.speech_bubble;
            this.pic_sb3.ImageRotate = 0F;
            this.pic_sb3.Location = new System.Drawing.Point(728, 184);
            this.pic_sb3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pic_sb3.Name = "pic_sb3";
            this.pic_sb3.Size = new System.Drawing.Size(162, 128);
            this.pic_sb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_sb3.TabIndex = 55;
            this.pic_sb3.TabStop = false;
            // 
            // pic_sb2
            // 
            this.pic_sb2.Image = global::client.Properties.Resources.speech_bubble;
            this.pic_sb2.ImageRotate = 0F;
            this.pic_sb2.Location = new System.Drawing.Point(452, 184);
            this.pic_sb2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pic_sb2.Name = "pic_sb2";
            this.pic_sb2.Size = new System.Drawing.Size(162, 128);
            this.pic_sb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_sb2.TabIndex = 54;
            this.pic_sb2.TabStop = false;
            // 
            // pic_sb1
            // 
            this.pic_sb1.Image = global::client.Properties.Resources.speech_bubble;
            this.pic_sb1.ImageRotate = 0F;
            this.pic_sb1.Location = new System.Drawing.Point(176, 184);
            this.pic_sb1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pic_sb1.Name = "pic_sb1";
            this.pic_sb1.Size = new System.Drawing.Size(162, 128);
            this.pic_sb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_sb1.TabIndex = 53;
            this.pic_sb1.TabStop = false;
            // 
            // txt_answer
            // 
            this.txt_answer.BorderColor = System.Drawing.Color.Black;
            this.txt_answer.BorderThickness = 2;
            this.txt_answer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_answer.DefaultText = "";
            this.txt_answer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_answer.ForeColor = System.Drawing.Color.Black;
            this.txt_answer.Location = new System.Drawing.Point(484, 616);
            this.txt_answer.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txt_answer.Name = "txt_answer";
            this.txt_answer.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txt_answer.PlaceholderText = "";
            this.txt_answer.SelectedText = "";
            this.txt_answer.Size = new System.Drawing.Size(374, 72);
            this.txt_answer.TabIndex = 52;
            this.txt_answer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_answer_KeyDown);
            // 
            // playerPic4
            // 
            this.playerPic4.Image = global::client.Properties.Resources.profile_image;
            this.playerPic4.ImageRotate = 0F;
            this.playerPic4.Location = new System.Drawing.Point(988, 312);
            this.playerPic4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.playerPic4.Name = "playerPic4";
            this.playerPic4.Size = new System.Drawing.Size(195, 192);
            this.playerPic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPic4.TabIndex = 51;
            this.playerPic4.TabStop = false;
            // 
            // playerPic3
            // 
            this.playerPic3.Image = global::client.Properties.Resources.profile_image;
            this.playerPic3.ImageRotate = 0F;
            this.playerPic3.Location = new System.Drawing.Point(712, 312);
            this.playerPic3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.playerPic3.Name = "playerPic3";
            this.playerPic3.Size = new System.Drawing.Size(195, 192);
            this.playerPic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPic3.TabIndex = 50;
            this.playerPic3.TabStop = false;
            // 
            // playerPic2
            // 
            this.playerPic2.Image = global::client.Properties.Resources.profile_image;
            this.playerPic2.ImageRotate = 0F;
            this.playerPic2.Location = new System.Drawing.Point(436, 312);
            this.playerPic2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.playerPic2.Name = "playerPic2";
            this.playerPic2.Size = new System.Drawing.Size(195, 192);
            this.playerPic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPic2.TabIndex = 49;
            this.playerPic2.TabStop = false;
            // 
            // playerPic1
            // 
            this.playerPic1.Image = global::client.Properties.Resources.profile_image;
            this.playerPic1.ImageRotate = 0F;
            this.playerPic1.Location = new System.Drawing.Point(159, 312);
            this.playerPic1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.playerPic1.Name = "playerPic1";
            this.playerPic1.Size = new System.Drawing.Size(195, 192);
            this.playerPic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerPic1.TabIndex = 48;
            this.playerPic1.TabStop = false;
            // 
            // txt_question
            // 
            this.txt_question.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_question.DefaultText = "３";
            this.txt_question.Font = new System.Drawing.Font("휴먼옛체", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_question.ForeColor = System.Drawing.Color.Black;
            this.txt_question.Location = new System.Drawing.Point(184, 24);
            this.txt_question.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.txt_question.Name = "txt_question";
            this.txt_question.PlaceholderText = "";
            this.txt_question.ReadOnly = true;
            this.txt_question.SelectedText = "";
            this.txt_question.Size = new System.Drawing.Size(975, 128);
            this.txt_question.TabIndex = 47;
            this.txt_question.TabStop = false;
            this.txt_question.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // answerReadyTimer
            // 
            this.answerReadyTimer.Interval = 1000;
            this.answerReadyTimer.Tick += new System.EventHandler(this.answerReadyTimer_Tick);
            // 
            // pname1
            // 
            this.pname1.AutoSize = true;
            this.pname1.Font = new System.Drawing.Font("휴먼옛체", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pname1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pname1.Location = new System.Drawing.Point(153, 514);
            this.pname1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pname1.Name = "pname1";
            this.pname1.Size = new System.Drawing.Size(49, 31);
            this.pname1.TabIndex = 78;
            this.pname1.Text = "1P";
            // 
            // pname2
            // 
            this.pname2.AutoSize = true;
            this.pname2.Font = new System.Drawing.Font("휴먼옛체", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pname2.ForeColor = System.Drawing.Color.Blue;
            this.pname2.Location = new System.Drawing.Point(429, 514);
            this.pname2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pname2.Name = "pname2";
            this.pname2.Size = new System.Drawing.Size(49, 31);
            this.pname2.TabIndex = 79;
            this.pname2.Text = "2P";
            // 
            // pname3
            // 
            this.pname3.AutoSize = true;
            this.pname3.Font = new System.Drawing.Font("휴먼옛체", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pname3.ForeColor = System.Drawing.Color.Goldenrod;
            this.pname3.Location = new System.Drawing.Point(705, 514);
            this.pname3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pname3.Name = "pname3";
            this.pname3.Size = new System.Drawing.Size(49, 31);
            this.pname3.TabIndex = 80;
            this.pname3.Text = "3P";
            // 
            // pname4
            // 
            this.pname4.AutoSize = true;
            this.pname4.Font = new System.Drawing.Font("휴먼옛체", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pname4.ForeColor = System.Drawing.Color.Green;
            this.pname4.Location = new System.Drawing.Point(982, 514);
            this.pname4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pname4.Name = "pname4";
            this.pname4.Size = new System.Drawing.Size(49, 31);
            this.pname4.TabIndex = 81;
            this.pname4.Text = "4P";
            // 
            // quizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.pname4);
            this.Controls.Add(this.pname3);
            this.Controls.Add(this.pname2);
            this.Controls.Add(this.pname1);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.playerAnswer4);
            this.Controls.Add(this.playerAnswer3);
            this.Controls.Add(this.playerAnswer2);
            this.Controls.Add(this.playerAnswer1);
            this.Controls.Add(this.player4Plus);
            this.Controls.Add(this.player3Plus);
            this.Controls.Add(this.player2Plus);
            this.Controls.Add(this.player1Plus);
            this.Controls.Add(this.playerScore4);
            this.Controls.Add(this.playerScore3);
            this.Controls.Add(this.playerScore2);
            this.Controls.Add(this.playerScore1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pic_sb4);
            this.Controls.Add(this.pic_sb3);
            this.Controls.Add(this.pic_sb2);
            this.Controls.Add(this.pic_sb1);
            this.Controls.Add(this.txt_answer);
            this.Controls.Add(this.playerPic4);
            this.Controls.Add(this.playerPic3);
            this.Controls.Add(this.playerPic2);
            this.Controls.Add(this.playerPic1);
            this.Controls.Add(this.txt_question);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "quizForm";
            this.Text = "quizForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.quizForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pic_sb4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_sb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPic1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Label playerAnswer4;
        private System.Windows.Forms.Label playerAnswer3;
        private System.Windows.Forms.Label playerAnswer2;
        private System.Windows.Forms.Label playerAnswer1;
        private System.Windows.Forms.Label player4Plus;
        private System.Windows.Forms.Label player3Plus;
        private System.Windows.Forms.Label player2Plus;
        private System.Windows.Forms.Label player1Plus;
        private System.Windows.Forms.Label playerScore4;
        private System.Windows.Forms.Label playerScore3;
        private System.Windows.Forms.Label playerScore2;
        private System.Windows.Forms.Label playerScore1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox pic_sb4;
        private Guna.UI2.WinForms.Guna2PictureBox pic_sb3;
        private Guna.UI2.WinForms.Guna2PictureBox pic_sb2;
        private Guna.UI2.WinForms.Guna2PictureBox pic_sb1;
        private Guna.UI2.WinForms.Guna2TextBox txt_answer;
        private Guna.UI2.WinForms.Guna2PictureBox playerPic4;
        private Guna.UI2.WinForms.Guna2PictureBox playerPic3;
        private Guna.UI2.WinForms.Guna2PictureBox playerPic2;
        private Guna.UI2.WinForms.Guna2PictureBox playerPic1;
        private Guna.UI2.WinForms.Guna2TextBox txt_question;
        private System.Windows.Forms.Timer quizStartTimer;
        private System.Windows.Forms.Timer answerReadyTimer;
        private System.Windows.Forms.Label pname1;
        private System.Windows.Forms.Label pname2;
        private System.Windows.Forms.Label pname3;
        private System.Windows.Forms.Label pname4;
    }
}