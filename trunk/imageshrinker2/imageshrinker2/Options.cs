using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageManipulator2
{
	public partial class Options : Form
	{
		public Options ()
		{
			InitializeComponent ();

			ToolTip ttToolTips = new ToolTip ();
			ttToolTips.AutoPopDelay = 5000;
			ttToolTips.InitialDelay = 1000;
			ttToolTips.ReshowDelay  = 500;
			ttToolTips.ShowAlways   = true;

			ttToolTips.SetToolTip (chkQuality, 
				"Quality mode takes a bit longer but produces much better results.");
			ttToolTips.SetToolTip (txtThreadCount,
				"This should be set to how many processing units your computer has\nif it was not detected properly.");
			ttToolTips.SetToolTip (this.radioBMP,
				"Bitmap format images are large but high quality and well supported");
			ttToolTips.SetToolTip (this.radioGIF,
				"Graphics Interchange Format is great for images with large blocks of\nsimilar colours (cartoons and web graphics)");
			ttToolTips.SetToolTip (this.radioJPEG,
				"Joint Pictures Expert Group format is excellent for compressing photographs.");
			ttToolTips.SetToolTip (this.radioPNG,
				"Portable Network Graphics format is good for cross compatiblity with many\nprograms and has moderate compression.");
			ttToolTips.SetToolTip (btnOK,
				"Sets the newly selected options and closes this dialog.");
			ttToolTips.SetToolTip (this.cmbPriority,
				"Sets the priority level of the threads used by this program.");

			this.cmbPriority.Items.Add (System.Threading.ThreadPriority.AboveNormal);
			this.cmbPriority.Items.Add (System.Threading.ThreadPriority.BelowNormal);
			this.cmbPriority.Items.Add (System.Threading.ThreadPriority.Highest);
			this.cmbPriority.Items.Add (System.Threading.ThreadPriority.Lowest);
			this.cmbPriority.Items.Add (System.Threading.ThreadPriority.Normal);
		}	

		public System.Drawing.Imaging.ImageFormat format
		{
			get
			{
				if (this.radioBMP.Checked)
					return ImageFormat.Bmp;
				if (this.radioGIF.Checked)
					return ImageFormat.Gif;
				if (this.radioJPEG.Checked)
					return ImageFormat.Jpeg;
				if (this.radioPNG.Checked)
					return ImageFormat.Png;
				return ImageFormat.Jpeg;
			}

			set
			{
				if (value == ImageFormat.Bmp)
					this.radioBMP.Select ();
				if (value == ImageFormat.Gif)
					this.radioGIF.Select ();
				if (value == ImageFormat.Jpeg)
					this.radioJPEG.Select ();
				if (value == ImageFormat.Png)
					this.radioPNG.Select ();
			}
		}

		public int threads
		{
			get
			{
				return Convert.ToInt32 (this.txtThreadCount.Value);
			}

			set
			{
				this.txtThreadCount.Value = value;
			}
		}

		public bool qualitymode
		{
			get
			{
				return this.chkQuality.Checked;
			}

			set
			{
				this.chkQuality.Checked = value;
			}
		}

		public System.Threading.ThreadPriority priority
		{
			get
			{
				return (System.Threading.ThreadPriority)this.cmbPriority.SelectedItem;
			}

			set
			{
				this.cmbPriority.SelectedItem = value;
			}
		}

		private void btnOK_Click (object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}