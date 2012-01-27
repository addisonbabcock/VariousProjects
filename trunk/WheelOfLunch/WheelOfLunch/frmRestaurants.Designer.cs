namespace WheelOfLunch
{
	partial class frmRestaurants
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
			this.grpBox = new System.Windows.Forms.GroupBox ();
			this.lblListStatus = new System.Windows.Forms.Label ();
			this.lblRestaurant = new System.Windows.Forms.Label ();
			this.btnClose = new System.Windows.Forms.Button ();
			this.filename = new System.Windows.Forms.TextBox ();
			this.label1 = new System.Windows.Forms.Label ();
			this.btnLoad = new System.Windows.Forms.Button ();
			this.grpBox.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// grpBox
			// 
			this.grpBox.Controls.Add (this.lblListStatus);
			this.grpBox.Controls.Add (this.lblRestaurant);
			this.grpBox.Location = new System.Drawing.Point (13, 13);
			this.grpBox.Name = "grpBox";
			this.grpBox.Size = new System.Drawing.Size (448, 461);
			this.grpBox.TabIndex = 0;
			this.grpBox.TabStop = false;
			this.grpBox.Text = "Restaurants";
			// 
			// lblListStatus
			// 
			this.lblListStatus.AutoSize = true;
			this.lblListStatus.Location = new System.Drawing.Point (112, 26);
			this.lblListStatus.Name = "lblListStatus";
			this.lblListStatus.Size = new System.Drawing.Size (56, 13);
			this.lblListStatus.TabIndex = 33;
			this.lblListStatus.Text = "List Status";
			// 
			// lblRestaurant
			// 
			this.lblRestaurant.AutoSize = true;
			this.lblRestaurant.Location = new System.Drawing.Point (6, 26);
			this.lblRestaurant.Name = "lblRestaurant";
			this.lblRestaurant.Size = new System.Drawing.Size (59, 13);
			this.lblRestaurant.TabIndex = 17;
			this.lblRestaurant.Text = "Restaurant";
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point (13, 564);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size (448, 46);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Save and close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler (this.btnClose_Click);
			// 
			// filename
			// 
			this.filename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.filename.Location = new System.Drawing.Point (13, 497);
			this.filename.Name = "filename";
			this.filename.Size = new System.Drawing.Size (448, 20);
			this.filename.TabIndex = 2;
			this.filename.Text = "RestaurantList.txt";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point (13, 481);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (55, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "File name:";
			// 
			// btnLoad
			// 
			this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoad.Location = new System.Drawing.Point (12, 523);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size (449, 35);
			this.btnLoad.TabIndex = 4;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler (this.btnLoad_Click);
			// 
			// frmRestaurants
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (473, 622);
			this.Controls.Add (this.btnLoad);
			this.Controls.Add (this.label1);
			this.Controls.Add (this.filename);
			this.Controls.Add (this.btnClose);
			this.Controls.Add (this.grpBox);
			this.Name = "frmRestaurants";
			this.Text = "The Menu";
			this.grpBox.ResumeLayout (false);
			this.grpBox.PerformLayout ();
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.GroupBox grpBox;
		private System.Windows.Forms.Label lblRestaurant;
		private System.Windows.Forms.Label lblListStatus;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TextBox filename;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnLoad;
	}
}