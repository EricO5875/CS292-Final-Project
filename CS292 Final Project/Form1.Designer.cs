namespace CS292_Final_Project
{
    partial class Form1
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
            this.chkShuffle = new System.Windows.Forms.CheckBox();
            this.chkLoop = new System.Windows.Forms.CheckBox();
            this.grpMusicControl = new System.Windows.Forms.GroupBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblMusicFilePath = new System.Windows.Forms.Label();
            this.btnLoadMusic = new System.Windows.Forms.Button();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlbum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpMusicControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // chkShuffle
            // 
            this.chkShuffle.AutoSize = true;
            this.chkShuffle.Location = new System.Drawing.Point(6, 27);
            this.chkShuffle.Name = "chkShuffle";
            this.chkShuffle.Size = new System.Drawing.Size(59, 17);
            this.chkShuffle.TabIndex = 0;
            this.chkShuffle.Text = "Shuffle";
            this.chkShuffle.UseVisualStyleBackColor = true;
            // 
            // chkLoop
            // 
            this.chkLoop.AutoSize = true;
            this.chkLoop.Location = new System.Drawing.Point(6, 65);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(50, 17);
            this.chkLoop.TabIndex = 1;
            this.chkLoop.Text = "Loop";
            this.chkLoop.UseVisualStyleBackColor = true;
            // 
            // grpMusicControl
            // 
            this.grpMusicControl.Controls.Add(this.chkLoop);
            this.grpMusicControl.Controls.Add(this.chkShuffle);
            this.grpMusicControl.Location = new System.Drawing.Point(193, 30);
            this.grpMusicControl.Name = "grpMusicControl";
            this.grpMusicControl.Size = new System.Drawing.Size(156, 102);
            this.grpMusicControl.TabIndex = 1;
            this.grpMusicControl.TabStop = false;
            this.grpMusicControl.Text = "Music Control";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(62, 180);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(188, 179);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(123, 218);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFileName,
            this.colTitle,
            this.colYear,
            this.colAlbum});
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.Location = new System.Drawing.Point(355, 12);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(480, 245);
            this.dgv.TabIndex = 6;
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Location = new System.Drawing.Point(568, 273);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(75, 23);
            this.btnEditInfo.TabIndex = 7;
            this.btnEditInfo.Text = "Edit Info";
            this.btnEditInfo.UseVisualStyleBackColor = true;
            this.btnEditInfo.Click += new System.EventHandler(this.btnEditInfo_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 39);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(159, 20);
            this.txtFilePath.TabIndex = 8;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(62, 67);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // lblMusicFilePath
            // 
            this.lblMusicFilePath.AutoSize = true;
            this.lblMusicFilePath.Location = new System.Drawing.Point(12, 23);
            this.lblMusicFilePath.Name = "lblMusicFilePath";
            this.lblMusicFilePath.Size = new System.Drawing.Size(82, 13);
            this.lblMusicFilePath.TabIndex = 10;
            this.lblMusicFilePath.Text = "Music File Path:";
            // 
            // btnLoadMusic
            // 
            this.btnLoadMusic.Location = new System.Drawing.Point(383, 273);
            this.btnLoadMusic.Name = "btnLoadMusic";
            this.btnLoadMusic.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMusic.TabIndex = 11;
            this.btnLoadMusic.Text = "Load Music";
            this.btnLoadMusic.UseVisualStyleBackColor = true;
            this.btnLoadMusic.Click += new System.EventHandler(this.btnLoadMusic_Click);
            // 
            // colFileName
            // 
            this.colFileName.HeaderText = "File Name";
            this.colFileName.Name = "colFileName";
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            // 
            // colYear
            // 
            this.colYear.HeaderText = "Year";
            this.colYear.Name = "colYear";
            // 
            // colAlbum
            // 
            this.colAlbum.HeaderText = "Album";
            this.colAlbum.Name = "colAlbum";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 325);
            this.Controls.Add(this.btnLoadMusic);
            this.Controls.Add(this.lblMusicFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnEditInfo);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.grpMusicControl);
            this.Name = "Form1";
            this.Text = "Music Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpMusicControl.ResumeLayout(false);
            this.grpMusicControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkShuffle;
        private System.Windows.Forms.CheckBox chkLoop;
        private System.Windows.Forms.GroupBox grpMusicControl;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnEditInfo;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblMusicFilePath;
        private System.Windows.Forms.Button btnLoadMusic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlbum;
    }
}

