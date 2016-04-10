namespace CS292_Final_Project
{
    partial class Add_Music
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
            this.btnLoadMusic = new System.Windows.Forms.Button();
            this.lblMusicFilePath = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.chkLstAddMusic = new System.Windows.Forms.CheckedListBox();
            this.btnAddMusic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadMusic
            // 
            this.btnLoadMusic.Location = new System.Drawing.Point(176, 73);
            this.btnLoadMusic.Name = "btnLoadMusic";
            this.btnLoadMusic.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMusic.TabIndex = 16;
            this.btnLoadMusic.Text = "Load Music";
            this.btnLoadMusic.UseVisualStyleBackColor = true;
            this.btnLoadMusic.Click += new System.EventHandler(this.btnLoadMusic_Click);
            // 
            // lblMusicFilePath
            // 
            this.lblMusicFilePath.AutoSize = true;
            this.lblMusicFilePath.Location = new System.Drawing.Point(92, 31);
            this.lblMusicFilePath.Name = "lblMusicFilePath";
            this.lblMusicFilePath.Size = new System.Drawing.Size(82, 13);
            this.lblMusicFilePath.TabIndex = 15;
            this.lblMusicFilePath.Text = "Music File Path:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(92, 73);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(92, 47);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(159, 20);
            this.txtFilePath.TabIndex = 13;
            // 
            // chkLstAddMusic
            // 
            this.chkLstAddMusic.FormattingEnabled = true;
            this.chkLstAddMusic.HorizontalScrollbar = true;
            this.chkLstAddMusic.Location = new System.Drawing.Point(53, 114);
            this.chkLstAddMusic.Name = "chkLstAddMusic";
            this.chkLstAddMusic.Size = new System.Drawing.Size(233, 289);
            this.chkLstAddMusic.TabIndex = 17;
            // 
            // btnAddMusic
            // 
            this.btnAddMusic.Location = new System.Drawing.Point(125, 426);
            this.btnAddMusic.Name = "btnAddMusic";
            this.btnAddMusic.Size = new System.Drawing.Size(75, 23);
            this.btnAddMusic.TabIndex = 18;
            this.btnAddMusic.Text = "Add Music";
            this.btnAddMusic.UseVisualStyleBackColor = true;
            this.btnAddMusic.Click += new System.EventHandler(this.btnAddMusic_Click);
            // 
            // Add_Music
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 461);
            this.Controls.Add(this.btnAddMusic);
            this.Controls.Add(this.chkLstAddMusic);
            this.Controls.Add(this.btnLoadMusic);
            this.Controls.Add(this.lblMusicFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Name = "Add_Music";
            this.Text = "Add Music";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadMusic;
        private System.Windows.Forms.Label lblMusicFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.CheckedListBox chkLstAddMusic;
        private System.Windows.Forms.Button btnAddMusic;
    }
}