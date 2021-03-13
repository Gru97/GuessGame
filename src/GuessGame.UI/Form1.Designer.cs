namespace GuessGame.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.gameCanvas = new System.Windows.Forms.Panel();
            this.lblJapanese = new System.Windows.Forms.Label();
            this.lblThai = new System.Windows.Forms.Label();
            this.lblKorean = new System.Windows.Forms.Label();
            this.lblChinese = new System.Windows.Forms.Label();
            this.pictureQuestion = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gameCanvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(468, 607);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(92, 22);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gameCanvas
            // 
            this.gameCanvas.Controls.Add(this.lblJapanese);
            this.gameCanvas.Controls.Add(this.lblThai);
            this.gameCanvas.Controls.Add(this.lblKorean);
            this.gameCanvas.Controls.Add(this.lblChinese);
            this.gameCanvas.Controls.Add(this.pictureQuestion);
            this.gameCanvas.Location = new System.Drawing.Point(30, 12);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Size = new System.Drawing.Size(1200, 570);
            this.gameCanvas.TabIndex = 7;
            // 
            // lblJapanese
            // 
            this.lblJapanese.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblJapanese.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJapanese.Location = new System.Drawing.Point(0, 420);
            this.lblJapanese.Name = "lblJapanese";
            this.lblJapanese.Size = new System.Drawing.Size(200, 150);
            this.lblJapanese.TabIndex = 8;
            this.lblJapanese.Text = "Japanese";
            this.lblJapanese.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThai
            // 
            this.lblThai.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblThai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblThai.Location = new System.Drawing.Point(1000, 420);
            this.lblThai.Name = "lblThai";
            this.lblThai.Size = new System.Drawing.Size(200, 150);
            this.lblThai.TabIndex = 7;
            this.lblThai.Text = "Thai";
            this.lblThai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKorean
            // 
            this.lblKorean.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblKorean.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKorean.Location = new System.Drawing.Point(1000, 0);
            this.lblKorean.Name = "lblKorean";
            this.lblKorean.Size = new System.Drawing.Size(200, 150);
            this.lblKorean.TabIndex = 6;
            this.lblKorean.Text = "Korean";
            this.lblKorean.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChinese
            // 
            this.lblChinese.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblChinese.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChinese.Location = new System.Drawing.Point(0, 0);
            this.lblChinese.Name = "lblChinese";
            this.lblChinese.Size = new System.Drawing.Size(200, 150);
            this.lblChinese.TabIndex = 5;
            this.lblChinese.Text = "Chinese";
            this.lblChinese.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureQuestion
            // 
            this.pictureQuestion.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureQuestion.Enabled = false;
            this.pictureQuestion.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pictureQuestion.Location = new System.Drawing.Point(522, 0);
            this.pictureQuestion.Name = "pictureQuestion";
            this.pictureQuestion.Size = new System.Drawing.Size(158, 143);
            this.pictureQuestion.TabIndex = 4;
            this.pictureQuestion.Text = "Guess My Nationality?";
            this.pictureQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pictureQuestion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureQuestion_MouseDown);
            this.pictureQuestion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureQuestion_MouseMove);
            this.pictureQuestion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureQuestion_MouseUp);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(817, 612);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(13, 15);
            this.lblScore.TabIndex = 9;
            this.lblScore.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(760, 611);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Score";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 650);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.gameCanvas);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gameCanvas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel gameCanvas;
        private System.Windows.Forms.Label lblChinese;
        private System.Windows.Forms.Label lblThai;
        private System.Windows.Forms.Label lblKorean;
        private System.Windows.Forms.Label Japanies;
        private System.Windows.Forms.Label lblJapanese;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pictureQuestion;
    }
}

