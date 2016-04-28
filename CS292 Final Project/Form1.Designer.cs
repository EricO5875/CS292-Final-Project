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
            this.dgvMusic = new System.Windows.Forms.DataGridView();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.grpVolume = new System.Windows.Forms.GroupBox();
            this.btnLower = new System.Windows.Forms.Button();
            this.btnRaise = new System.Windows.Forms.Button();
            this.lblVolume = new System.Windows.Forms.Label();
            this.btnAddMusic = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpMusicControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusic)).BeginInit();
            this.grpVolume.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkShuffle
            // 
            this.chkShuffle.AutoSize = true;
            this.chkShuffle.Location = new System.Drawing.Point(6, 22);
            this.chkShuffle.Name = "chkShuffle";
            this.chkShuffle.Size = new System.Drawing.Size(59, 17);
            this.chkShuffle.TabIndex = 0;
            this.chkShuffle.Text = "Shuffle";
            this.chkShuffle.UseVisualStyleBackColor = true;
            // 
            // chkLoop
            // 
            this.chkLoop.AutoSize = true;
            this.chkLoop.Location = new System.Drawing.Point(6, 48);
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
            this.grpMusicControl.Location = new System.Drawing.Point(289, 275);
            this.grpMusicControl.Name = "grpMusicControl";
            this.grpMusicControl.Size = new System.Drawing.Size(96, 82);
            this.grpMusicControl.TabIndex = 1;
            this.grpMusicControl.TabStop = false;
            this.grpMusicControl.Text = "Music Control";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(40, 275);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(135, 275);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(40, 334);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvMusic
            // 
            this.dgvMusic.AllowUserToAddRows = false;
            this.dgvMusic.AllowUserToDeleteRows = false;
            this.dgvMusic.AllowUserToResizeRows = false;
            this.dgvMusic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusic.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMusic.Location = new System.Drawing.Point(11, 12);
            this.dgvMusic.MultiSelect = false;
            this.dgvMusic.Name = "dgvMusic";
            this.dgvMusic.ReadOnly = true;
            this.dgvMusic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMusic.Size = new System.Drawing.Size(763, 245);
            this.dgvMusic.TabIndex = 6;
            this.dgvMusic.SelectionChanged += new System.EventHandler(this.dgvMusic_SelectionChanged);
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Location = new System.Drawing.Point(474, 362);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(75, 23);
            this.btnEditInfo.TabIndex = 7;
            this.btnEditInfo.Text = "Edit Info...";
            this.btnEditInfo.UseVisualStyleBackColor = true;
            this.btnEditInfo.Click += new System.EventHandler(this.btnEditInfo_Click);
            // 
            // grpVolume
            // 
            this.grpVolume.Controls.Add(this.btnLower);
            this.grpVolume.Controls.Add(this.btnRaise);
            this.grpVolume.Controls.Add(this.lblVolume);
            this.grpVolume.Location = new System.Drawing.Point(447, 275);
            this.grpVolume.Name = "grpVolume";
            this.grpVolume.Size = new System.Drawing.Size(239, 55);
            this.grpVolume.TabIndex = 12;
            this.grpVolume.TabStop = false;
            this.grpVolume.Text = "Volume";
            // 
            // btnLower
            // 
            this.btnLower.Location = new System.Drawing.Point(141, 18);
            this.btnLower.Name = "btnLower";
            this.btnLower.Size = new System.Drawing.Size(75, 23);
            this.btnLower.TabIndex = 4;
            this.btnLower.Text = "Lower";
            this.btnLower.UseVisualStyleBackColor = true;
            this.btnLower.Click += new System.EventHandler(this.btnLower_Click_1);
            // 
            // btnRaise
            // 
            this.btnRaise.Location = new System.Drawing.Point(27, 18);
            this.btnRaise.Name = "btnRaise";
            this.btnRaise.Size = new System.Drawing.Size(75, 23);
            this.btnRaise.TabIndex = 3;
            this.btnRaise.Text = "Raise";
            this.btnRaise.UseVisualStyleBackColor = true;
            this.btnRaise.Click += new System.EventHandler(this.btnRaise_Click_1);
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(108, 26);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(27, 13);
            this.lblVolume.TabIndex = 2;
            this.lblVolume.Text = "25%";
            // 
            // btnAddMusic
            // 
            this.btnAddMusic.Location = new System.Drawing.Point(588, 362);
            this.btnAddMusic.Name = "btnAddMusic";
            this.btnAddMusic.Size = new System.Drawing.Size(75, 23);
            this.btnAddMusic.TabIndex = 13;
            this.btnAddMusic.Text = "Add Music...";
            this.btnAddMusic.UseVisualStyleBackColor = true;
            this.btnAddMusic.Click += new System.EventHandler(this.btnAddMusic_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 412);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(786, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 434);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnAddMusic);
            this.Controls.Add(this.grpVolume);
            this.Controls.Add(this.btnEditInfo);
            this.Controls.Add(this.dgvMusic);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.grpMusicControl);
            this.Name = "Form1";
            this.Text = "Music Player";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpMusicControl.ResumeLayout(false);
            this.grpMusicControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusic)).EndInit();
            this.grpVolume.ResumeLayout(false);
            this.grpVolume.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvMusic;
        private System.Windows.Forms.Button btnEditInfo;
        private System.Windows.Forms.GroupBox grpVolume;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Button btnAddMusic;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnLower;
        private System.Windows.Forms.Button btnRaise;
    }
}

