namespace WheelOfLunch
{
	partial class frmMain
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.btnSpin = new System.Windows.Forms.Button();
			this.rendertimer = new System.Windows.Forms.Timer(this.components);
			this.btnRestaurants = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSpin
			// 
			this.btnSpin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSpin.Location = new System.Drawing.Point(12, 711);
			this.btnSpin.Name = "btnSpin";
			this.btnSpin.Size = new System.Drawing.Size(75, 23);
			this.btnSpin.TabIndex = 0;
			this.btnSpin.Text = "Spin";
			this.btnSpin.UseVisualStyleBackColor = true;
			this.btnSpin.Click += new System.EventHandler(this.btnSpin_Click);
			// 
			// rendertimer
			// 
			this.rendertimer.Interval = 16;
			this.rendertimer.Tick += new System.EventHandler(this.rendertimer_Tick);
			// 
			// btnRestaurants
			// 
			this.btnRestaurants.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRestaurants.Location = new System.Drawing.Point(731, 711);
			this.btnRestaurants.Name = "btnRestaurants";
			this.btnRestaurants.Size = new System.Drawing.Size(75, 23);
			this.btnRestaurants.TabIndex = 1;
			this.btnRestaurants.Text = "Restaurants";
			this.btnRestaurants.UseVisualStyleBackColor = true;
			this.btnRestaurants.Click += new System.EventHandler(this.btnRestaurants_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(818, 746);
			this.Controls.Add(this.btnRestaurants);
			this.Controls.Add(this.btnSpin);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.Text = "Wheel of Lunch";
			this.Shown += new System.EventHandler(this.frmMain_Shown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnSpin;
		private System.Windows.Forms.Timer rendertimer;
		private System.Windows.Forms.Button btnRestaurants;
	}
}

