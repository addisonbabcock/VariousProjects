namespace ImageManipulator2
{
    partial class MainForm
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
			this.lblSrcPath = new System.Windows.Forms.Label();
			this.lblDestPath = new System.Windows.Forms.Label();
			this.txtSrcPath = new System.Windows.Forms.TextBox();
			this.txtDestPath = new System.Windows.Forms.TextBox();
			this.btnSrcPathSel = new System.Windows.Forms.Button();
			this.btnDestPathSel = new System.Windows.Forms.Button();
			this.btnGo = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.lblWidth = new System.Windows.Forms.Label();
			this.lblHeight = new System.Windows.Forms.Label();
			this.lstboxLog = new System.Windows.Forms.ListBox();
			this.progbarProg = new System.Windows.Forms.ProgressBar();
			this.dlgSrcSel = new System.Windows.Forms.FolderBrowserDialog();
			this.dlgDestSel = new System.Windows.Forms.FolderBrowserDialog();
			this.btnOptions = new System.Windows.Forms.Button();
			this.ssStats = new System.Windows.Forms.StatusStrip();
			this.tslblThreadsRunning = new System.Windows.Forms.ToolStripStatusLabel();
			this.tslblFilesRemaining = new System.Windows.Forms.ToolStripStatusLabel();
			this.tslblTimeRemaining = new System.Windows.Forms.ToolStripStatusLabel();
			this.tmrSeconds = new System.Windows.Forms.Timer(this.components);
			this.ssStats.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblSrcPath
			// 
			this.lblSrcPath.AutoSize = true;
			this.lblSrcPath.Location = new System.Drawing.Point(12, 17);
			this.lblSrcPath.Name = "lblSrcPath";
			this.lblSrcPath.Size = new System.Drawing.Size(44, 13);
			this.lblSrcPath.TabIndex = 0;
			this.lblSrcPath.Text = "Source:";
			// 
			// lblDestPath
			// 
			this.lblDestPath.AutoSize = true;
			this.lblDestPath.Location = new System.Drawing.Point(12, 46);
			this.lblDestPath.Name = "lblDestPath";
			this.lblDestPath.Size = new System.Drawing.Size(63, 13);
			this.lblDestPath.TabIndex = 1;
			this.lblDestPath.Text = "Destination:";
			// 
			// txtSrcPath
			// 
			this.txtSrcPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSrcPath.Location = new System.Drawing.Point(81, 14);
			this.txtSrcPath.Name = "txtSrcPath";
			this.txtSrcPath.Size = new System.Drawing.Size(298, 20);
			this.txtSrcPath.TabIndex = 0;
			this.txtSrcPath.Text = "Y:\\pictures\\highres";
			// 
			// txtDestPath
			// 
			this.txtDestPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDestPath.Location = new System.Drawing.Point(81, 43);
			this.txtDestPath.Name = "txtDestPath";
			this.txtDestPath.Size = new System.Drawing.Size(298, 20);
			this.txtDestPath.TabIndex = 2;
			this.txtDestPath.Text = "Z:\\lowres";
			// 
			// btnSrcPathSel
			// 
			this.btnSrcPathSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSrcPathSel.Location = new System.Drawing.Point(385, 12);
			this.btnSrcPathSel.Name = "btnSrcPathSel";
			this.btnSrcPathSel.Size = new System.Drawing.Size(75, 23);
			this.btnSrcPathSel.TabIndex = 1;
			this.btnSrcPathSel.Text = "Browse...";
			this.btnSrcPathSel.UseVisualStyleBackColor = true;
			this.btnSrcPathSel.Click += new System.EventHandler(this.btnSrcPathSel_Click);
			// 
			// btnDestPathSel
			// 
			this.btnDestPathSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDestPathSel.Location = new System.Drawing.Point(385, 41);
			this.btnDestPathSel.Name = "btnDestPathSel";
			this.btnDestPathSel.Size = new System.Drawing.Size(75, 23);
			this.btnDestPathSel.TabIndex = 3;
			this.btnDestPathSel.Text = "Browse...";
			this.btnDestPathSel.UseVisualStyleBackColor = true;
			this.btnDestPathSel.Click += new System.EventHandler(this.btnDestPathSel_Click);
			// 
			// btnGo
			// 
			this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGo.Location = new System.Drawing.Point(385, 71);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(75, 46);
			this.btnGo.TabIndex = 6;
			this.btnGo.Text = "Go";
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Enabled = false;
			this.btnCancel.Location = new System.Drawing.Point(304, 71);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 46);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtWidth
			// 
			this.txtWidth.Location = new System.Drawing.Point(81, 71);
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.Size = new System.Drawing.Size(136, 20);
			this.txtWidth.TabIndex = 4;
			this.txtWidth.Text = "300";
			// 
			// txtHeight
			// 
			this.txtHeight.Location = new System.Drawing.Point(81, 97);
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.Size = new System.Drawing.Size(136, 20);
			this.txtHeight.TabIndex = 5;
			this.txtHeight.Text = "300";
			// 
			// lblWidth
			// 
			this.lblWidth.AutoSize = true;
			this.lblWidth.Location = new System.Drawing.Point(12, 74);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(38, 13);
			this.lblWidth.TabIndex = 10;
			this.lblWidth.Text = "Width:";
			// 
			// lblHeight
			// 
			this.lblHeight.AutoSize = true;
			this.lblHeight.Location = new System.Drawing.Point(12, 100);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(41, 13);
			this.lblHeight.TabIndex = 11;
			this.lblHeight.Text = "Height:";
			// 
			// lstboxLog
			// 
			this.lstboxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lstboxLog.Enabled = false;
			this.lstboxLog.FormattingEnabled = true;
			this.lstboxLog.Location = new System.Drawing.Point(12, 124);
			this.lstboxLog.Name = "lstboxLog";
			this.lstboxLog.Size = new System.Drawing.Size(448, 147);
			this.lstboxLog.TabIndex = 12;
			this.lstboxLog.TabStop = false;
			// 
			// progbarProg
			// 
			this.progbarProg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.progbarProg.Enabled = false;
			this.progbarProg.Location = new System.Drawing.Point(12, 277);
			this.progbarProg.Name = "progbarProg";
			this.progbarProg.Size = new System.Drawing.Size(448, 23);
			this.progbarProg.TabIndex = 13;
			// 
			// btnOptions
			// 
			this.btnOptions.Location = new System.Drawing.Point(223, 71);
			this.btnOptions.Name = "btnOptions";
			this.btnOptions.Size = new System.Drawing.Size(75, 46);
			this.btnOptions.TabIndex = 14;
			this.btnOptions.Text = "Options";
			this.btnOptions.UseVisualStyleBackColor = true;
			this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
			// 
			// ssStats
			// 
			this.ssStats.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblThreadsRunning,
            this.tslblFilesRemaining,
            this.tslblTimeRemaining});
			this.ssStats.Location = new System.Drawing.Point(0, 303);
			this.ssStats.Name = "ssStats";
			this.ssStats.Size = new System.Drawing.Size(472, 22);
			this.ssStats.TabIndex = 15;
			this.ssStats.Text = "statusStrip1";
			// 
			// tslblThreadsRunning
			// 
			this.tslblThreadsRunning.Name = "tslblThreadsRunning";
			this.tslblThreadsRunning.Size = new System.Drawing.Size(101, 17);
			this.tslblThreadsRunning.Text = "Threads Running: 0";
			this.tslblThreadsRunning.ToolTipText = "How many conversion threads are currently running.";
			// 
			// tslblFilesRemaining
			// 
			this.tslblFilesRemaining.Name = "tslblFilesRemaining";
			this.tslblFilesRemaining.Size = new System.Drawing.Size(93, 17);
			this.tslblFilesRemaining.Text = "Files Remaining: 0";
			this.tslblFilesRemaining.ToolTipText = "How many files remain to be converted or resized.";
			// 
			// tslblTimeRemaining
			// 
			this.tslblTimeRemaining.Name = "tslblTimeRemaining";
			this.tslblTimeRemaining.Size = new System.Drawing.Size(94, 17);
			this.tslblTimeRemaining.Text = "Time Remaining: 0";
			this.tslblTimeRemaining.ToolTipText = "An estimation of how much longer the conversion process will take.";
			// 
			// tmrSeconds
			// 
			this.tmrSeconds.Interval = 1000;
			this.tmrSeconds.Tick += new System.EventHandler(this.tmrSeconds_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(472, 325);
			this.Controls.Add(this.ssStats);
			this.Controls.Add(this.btnOptions);
			this.Controls.Add(this.progbarProg);
			this.Controls.Add(this.lstboxLog);
			this.Controls.Add(this.lblHeight);
			this.Controls.Add(this.lblWidth);
			this.Controls.Add(this.txtHeight);
			this.Controls.Add(this.txtWidth);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnGo);
			this.Controls.Add(this.btnDestPathSel);
			this.Controls.Add(this.btnSrcPathSel);
			this.Controls.Add(this.txtDestPath);
			this.Controls.Add(this.txtSrcPath);
			this.Controls.Add(this.lblDestPath);
			this.Controls.Add(this.lblSrcPath);
			this.Name = "MainForm";
			this.Text = "Image Manipulator 2.0";
			this.ssStats.ResumeLayout(false);
			this.ssStats.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSrcPath;
        private System.Windows.Forms.Label lblDestPath;
        private System.Windows.Forms.TextBox txtSrcPath;
        private System.Windows.Forms.TextBox txtDestPath;
        private System.Windows.Forms.Button btnSrcPathSel;
        private System.Windows.Forms.Button btnDestPathSel;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.ListBox lstboxLog;
        private System.Windows.Forms.ProgressBar progbarProg;
        private System.Windows.Forms.FolderBrowserDialog dlgSrcSel;
        private System.Windows.Forms.FolderBrowserDialog dlgDestSel;
		private System.Windows.Forms.Button btnOptions;
		private System.Windows.Forms.StatusStrip ssStats;
		private System.Windows.Forms.ToolStripStatusLabel tslblThreadsRunning;
		private System.Windows.Forms.ToolStripStatusLabel tslblFilesRemaining;
		private System.Windows.Forms.ToolStripStatusLabel tslblTimeRemaining;
		private System.Windows.Forms.Timer tmrSeconds;
    }
}

