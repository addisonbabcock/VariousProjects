namespace BattleOfLunchClient
{
	partial class ClientForm
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
			this.mIPAddress = new System.Windows.Forms.TextBox ();
			this.mPort = new System.Windows.Forms.TextBox ();
			this.Connect = new System.Windows.Forms.Button ();
			this.SuspendLayout ();
			// 
			// mIPAddress
			// 
			this.mIPAddress.Location = new System.Drawing.Point (149, 166);
			this.mIPAddress.Name = "mIPAddress";
			this.mIPAddress.Size = new System.Drawing.Size (100, 20);
			this.mIPAddress.TabIndex = 0;
			this.mIPAddress.Text = "127.0.0.1";
			// 
			// mPort
			// 
			this.mPort.Location = new System.Drawing.Point (255, 166);
			this.mPort.Name = "mPort";
			this.mPort.Size = new System.Drawing.Size (100, 20);
			this.mPort.TabIndex = 1;
			this.mPort.Text = "56666";
			// 
			// Connect
			// 
			this.Connect.Location = new System.Drawing.Point (361, 164);
			this.Connect.Name = "Connect";
			this.Connect.Size = new System.Drawing.Size (75, 23);
			this.Connect.TabIndex = 2;
			this.Connect.Text = "Connect";
			this.Connect.UseVisualStyleBackColor = true;
			this.Connect.Click += new System.EventHandler (this.Connect_Click);
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (576, 453);
			this.Controls.Add (this.Connect);
			this.Controls.Add (this.mPort);
			this.Controls.Add (this.mIPAddress);
			this.Name = "ClientForm";
			this.Text = "Client";
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.TextBox mIPAddress;
		private System.Windows.Forms.TextBox mPort;
		private System.Windows.Forms.Button Connect;
	}
}

