namespace ImageManipulator2
{
	partial class Options
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox ();
			this.radioGIF = new System.Windows.Forms.RadioButton ();
			this.radioBMP = new System.Windows.Forms.RadioButton ();
			this.radioPNG = new System.Windows.Forms.RadioButton ();
			this.radioJPEG = new System.Windows.Forms.RadioButton ();
			this.lblThreadCount = new System.Windows.Forms.Label ();
			this.txtThreadCount = new System.Windows.Forms.NumericUpDown ();
			this.btnOK = new System.Windows.Forms.Button ();
			this.chkQuality = new System.Windows.Forms.CheckBox ();
			this.cmbPriority = new System.Windows.Forms.ComboBox ();
			this.lblPriority = new System.Windows.Forms.Label ();
			this.groupBox1.SuspendLayout ();
			((System.ComponentModel.ISupportInitialize)(this.txtThreadCount)).BeginInit ();
			this.SuspendLayout ();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add (this.radioGIF);
			this.groupBox1.Controls.Add (this.radioBMP);
			this.groupBox1.Controls.Add (this.radioPNG);
			this.groupBox1.Controls.Add (this.radioJPEG);
			this.groupBox1.Location = new System.Drawing.Point (12, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size (70, 120);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Format";
			// 
			// radioGIF
			// 
			this.radioGIF.AutoSize = true;
			this.radioGIF.Location = new System.Drawing.Point (7, 96);
			this.radioGIF.Name = "radioGIF";
			this.radioGIF.Size = new System.Drawing.Size (42, 17);
			this.radioGIF.TabIndex = 3;
			this.radioGIF.TabStop = true;
			this.radioGIF.Text = "GIF";
			this.radioGIF.UseVisualStyleBackColor = true;
			// 
			// radioBMP
			// 
			this.radioBMP.AutoSize = true;
			this.radioBMP.Location = new System.Drawing.Point (7, 70);
			this.radioBMP.Name = "radioBMP";
			this.radioBMP.Size = new System.Drawing.Size (48, 17);
			this.radioBMP.TabIndex = 2;
			this.radioBMP.TabStop = true;
			this.radioBMP.Text = "BMP";
			this.radioBMP.UseVisualStyleBackColor = true;
			// 
			// radioPNG
			// 
			this.radioPNG.AutoSize = true;
			this.radioPNG.Location = new System.Drawing.Point (7, 45);
			this.radioPNG.Name = "radioPNG";
			this.radioPNG.Size = new System.Drawing.Size (48, 17);
			this.radioPNG.TabIndex = 1;
			this.radioPNG.TabStop = true;
			this.radioPNG.Text = "PNG";
			this.radioPNG.UseVisualStyleBackColor = true;
			// 
			// radioJPEG
			// 
			this.radioJPEG.AutoSize = true;
			this.radioJPEG.Location = new System.Drawing.Point (7, 20);
			this.radioJPEG.Name = "radioJPEG";
			this.radioJPEG.Size = new System.Drawing.Size (52, 17);
			this.radioJPEG.TabIndex = 0;
			this.radioJPEG.TabStop = true;
			this.radioJPEG.Text = "JPEG";
			this.radioJPEG.UseVisualStyleBackColor = true;
			// 
			// lblThreadCount
			// 
			this.lblThreadCount.AutoSize = true;
			this.lblThreadCount.Location = new System.Drawing.Point (88, 35);
			this.lblThreadCount.Name = "lblThreadCount";
			this.lblThreadCount.Size = new System.Drawing.Size (105, 13);
			this.lblThreadCount.TabIndex = 1;
			this.lblThreadCount.Text = "Conversion Threads:";
			// 
			// txtThreadCount
			// 
			this.txtThreadCount.Location = new System.Drawing.Point (199, 33);
			this.txtThreadCount.Maximum = new decimal (new int [] {
            8,
            0,
            0,
            0});
			this.txtThreadCount.Minimum = new decimal (new int [] {
            1,
            0,
            0,
            0});
			this.txtThreadCount.Name = "txtThreadCount";
			this.txtThreadCount.Size = new System.Drawing.Size (116, 20);
			this.txtThreadCount.TabIndex = 2;
			this.txtThreadCount.Value = new decimal (new int [] {
            2,
            0,
            0,
            0});
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point (199, 91);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size (116, 42);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler (this.btnOK_Click);
			// 
			// chkQuality
			// 
			this.chkQuality.AutoSize = true;
			this.chkQuality.Location = new System.Drawing.Point (91, 110);
			this.chkQuality.Name = "chkQuality";
			this.chkQuality.Size = new System.Drawing.Size (88, 17);
			this.chkQuality.TabIndex = 4;
			this.chkQuality.Text = "Quality Mode";
			this.chkQuality.UseVisualStyleBackColor = true;
			// 
			// cmbPriority
			// 
			this.cmbPriority.FormattingEnabled = true;
			this.cmbPriority.Location = new System.Drawing.Point (199, 57);
			this.cmbPriority.Name = "cmbPriority";
			this.cmbPriority.Size = new System.Drawing.Size (116, 21);
			this.cmbPriority.TabIndex = 5;
			// 
			// lblPriority
			// 
			this.lblPriority.AutoSize = true;
			this.lblPriority.Location = new System.Drawing.Point (88, 60);
			this.lblPriority.Name = "lblPriority";
			this.lblPriority.Size = new System.Drawing.Size (78, 13);
			this.lblPriority.TabIndex = 6;
			this.lblPriority.Text = "Thread Priority:";
			// 
			// Options
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (326, 145);
			this.Controls.Add (this.lblPriority);
			this.Controls.Add (this.cmbPriority);
			this.Controls.Add (this.chkQuality);
			this.Controls.Add (this.btnOK);
			this.Controls.Add (this.txtThreadCount);
			this.Controls.Add (this.lblThreadCount);
			this.Controls.Add (this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Options";
			this.Text = "Options";
			this.groupBox1.ResumeLayout (false);
			this.groupBox1.PerformLayout ();
			((System.ComponentModel.ISupportInitialize)(this.txtThreadCount)).EndInit ();
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioGIF;
		private System.Windows.Forms.RadioButton radioBMP;
		private System.Windows.Forms.RadioButton radioPNG;
		private System.Windows.Forms.RadioButton radioJPEG;
		private System.Windows.Forms.Label lblThreadCount;
		private System.Windows.Forms.NumericUpDown txtThreadCount;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.CheckBox chkQuality;
		private System.Windows.Forms.ComboBox cmbPriority;
		private System.Windows.Forms.Label lblPriority;
	}
}