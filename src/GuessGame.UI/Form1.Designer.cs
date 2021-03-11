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
            this.pictureQuestion = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gameCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(602, 605);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(92, 22);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gameCanvas
            // 
            this.gameCanvas.Controls.Add(this.label1);
            this.gameCanvas.Controls.Add(this.pictureQuestion);
            this.gameCanvas.Location = new System.Drawing.Point(30, 12);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Size = new System.Drawing.Size(1200, 570);
            this.gameCanvas.TabIndex = 7;
            // 
            // pictureQuestion
            // 
            this.pictureQuestion.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureQuestion.Location = new System.Drawing.Point(500, 14);
            this.pictureQuestion.Name = "pictureQuestion";
            this.pictureQuestion.Size = new System.Drawing.Size(164, 119);
            this.pictureQuestion.TabIndex = 4;
            this.pictureQuestion.TabStop = false;
            this.pictureQuestion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureQuestion_MouseDown);
            this.pictureQuestion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureQuestion_MouseMove);
            this.pictureQuestion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureQuestion_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 650);
            this.Controls.Add(this.gameCanvas);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gameCanvas.ResumeLayout(false);
            this.gameCanvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel gameCanvas;
        private System.Windows.Forms.PictureBox pictureQuestion;
        private System.Windows.Forms.Label label1;
    }
}

