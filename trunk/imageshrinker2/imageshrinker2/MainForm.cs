using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ImageManipulator2
{
	delegate void delVoidString (String msg);
	delegate void delVoidVoid ();

	public partial class MainForm : Form
	{
		private LockingBuffer<FileInfo> buffer;
		private FileListGenerator filelistgen;
		private FileConvertor [] convertors;
		private int threadsRunning;
		private Options dlgOptions;
		private System.TimeSpan runTime;
		
		public MainForm ()
		{
			InitializeComponent ();
			this.dlgDestSel.SelectedPath = this.txtDestPath.Text;
			this.dlgSrcSel.SelectedPath = this.txtSrcPath.Text;
			buffer = new LockingBuffer<FileInfo> ();
			filelistgen = new FileListGenerator (buffer, this);

			threadsRunning = 0;
			dlgOptions = new Options ();
			dlgOptions.threads = 2;
			dlgOptions.format = ImageFormat.Jpeg;
			dlgOptions.qualitymode = true;
			dlgOptions.priority = System.Threading.ThreadPriority.BelowNormal;

			ToolTip ttToolTips = new ToolTip ();
			ttToolTips.AutoPopDelay = 5000;
			ttToolTips.InitialDelay = 1000;
			ttToolTips.ReshowDelay = 500;
			ttToolTips.ShowAlways = true;

			ttToolTips.SetToolTip (this.txtDestPath,
				"The path where the new resized images will be saved.");
			ttToolTips.SetToolTip (this.txtSrcPath,
				"The directory to scan for images to resize.");
			ttToolTips.SetToolTip (this.txtHeight,
				"The desired height in pixels of the new images.");
			ttToolTips.SetToolTip (this.txtWidth,
				"The desired width in pixels of the new images.");
			ttToolTips.SetToolTip (this.btnGo,
				"Start the conversion process.");
			ttToolTips.SetToolTip (this.btnCancel,
				"Cancel the conversion process.");
			ttToolTips.SetToolTip (this.btnOptions,
				"Show the options menu.");
			ttToolTips.SetToolTip (this.progbarProg,
				"Gives a visual indication of how many images remain to convert.");
			ttToolTips.SetToolTip (this.lstboxLog,
				"Shows what images the program is currently processing.");
		}

		public void UpdateUI ()
		{
			if (threadsRunning != 0)
			{
				this.txtDestPath.Enabled = false;
				this.txtSrcPath.Enabled = false;
				this.txtHeight.Enabled = false;
				this.txtWidth.Enabled = false;
				this.btnGo.Enabled = false;
				this.btnDestPathSel.Enabled = false;
				this.btnSrcPathSel.Enabled = false;
				this.btnOptions.Enabled = false;
				this.btnCancel.Enabled = true;
//				this.lstboxLog.Enabled = true;
//				this.progbarProg.Enabled = true;
				this.tmrSeconds.Enabled = true;
				this.tslblThreadsRunning.Text = 
					"Threads Running: " + 
					this.threadsRunning.ToString ();
				int iFilesRemaining = (this.progbarProg.Maximum - this.progbarProg.Value);
				this.tslblFilesRemaining.Text =
					"Files Remaining: " +
					iFilesRemaining.ToString ();

				if ((double)this.progbarProg.Value != 0 && runTime.TotalSeconds != 0.0)
				{
//					TimeSpan remaining = new TimeSpan ((int)((double)this.progbarProg.Value / 
//						runTime.TotalSeconds * iFilesRemaining) * 10000000);
					TimeSpan remaining = new TimeSpan (0, 0, (int)(
						(runTime.TotalSeconds / (double)this.progbarProg.Value) *
						(double)iFilesRemaining));
					this.tslblTimeRemaining.Text = "Time Remaining: " +
						remaining.Hours + ":" + 
						remaining.Minutes.ToString ("00") + ":" + 
						remaining.Seconds.ToString ("00");
				}
				else
				{
					this.tslblTimeRemaining.Text = "Time Remaining: Unknown";
				}
			}
			else
			{
				this.txtDestPath.Enabled = true;
				this.txtSrcPath.Enabled = true;
				this.txtHeight.Enabled = true;
				this.txtWidth.Enabled = true;
				this.btnGo.Enabled = true;
				this.btnDestPathSel.Enabled = true;
				this.btnSrcPathSel.Enabled = true;
				this.btnOptions.Enabled = true;
				this.btnCancel.Enabled = false;
//				this.progbarProg.Enabled = false;
				this.progbarProg.Value = 0;
				this.progbarProg.Maximum = 0;
				this.tslblFilesRemaining.Text = "Files Remaining: 0";
				this.tslblThreadsRunning.Text = "Threads Running: 0";
				this.tslblTimeRemaining.Text = "Time Remaining: ";
				this.tmrSeconds.Enabled = false;
				runTime = new TimeSpan ();
			}
		}

		public void AddLogMsg (String msg)
		{
			if (this.lstboxLog.InvokeRequired)
			{
				try
				{
				Invoke (new delVoidString (AddLogMsg),
						new object [] { msg });
				}
				catch 
				{
				}
			}
			else
			{
//				if (this.lstboxLog.Items.Count == 100)
//					this.lstboxLog.Items.RemoveAt (0);
				this.lstboxLog.Items.Add (msg);
				this.lstboxLog.SelectedIndex = this.lstboxLog.Items.Count - 1;
				this.lstboxLog.SelectedIndex = -1;
//				UpdateUI ();
			}
		}

		public void ClearLog (String nothing)
		{
			if (this.lstboxLog.InvokeRequired)
			{
				Invoke (new delVoidString (ClearLog),
						new object [] { "" });
			}
			else
			{
				this.lstboxLog.Items.Clear ();
				this.progbarProg.Value = 0;
				this.progbarProg.Maximum = 0;
				UpdateUI ();
			}
		}

		public void ThreadEnded (String threadName)
		{
			if (this.InvokeRequired)
			{
				Invoke (new delVoidString (ThreadEnded),
						new object [] { threadName });
			}
			else
			{
				--threadsRunning;
				AddLogMsg (threadName + " ended.");
				UpdateUI ();

				if (threadsRunning == 0)
				{
					GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
				}
			}
		}

		public void IncQueueSize ()
		{
			if (this.progbarProg.InvokeRequired)
			{
				Invoke (new delVoidVoid (IncQueueSize));
			}
			else
			{
				this.progbarProg.Maximum += 1;
//				UpdateUI ();
			}
		}

		public void IncProcessedSize ()
		{
			if (this.progbarProg.InvokeRequired)
			{
				Invoke (new delVoidVoid (IncProcessedSize));
			}
			else
			{
				this.progbarProg.Value += 1;
//				UpdateUI ();
			}
		}

		private void btnGo_Click (object sender, EventArgs e)
		{
			ClearLog ("");
			buffer.Clear ();
			StartThreads ();
			UpdateUI ();
		}

		private void btnCancel_Click (object sender, EventArgs e)
		{
			StopThreads ();
		}

		private void StartThreads ()
		{
			try
			{
				int iW = Convert.ToInt32 (this.txtWidth.Text);
				int iH = Convert.ToInt32 (this.txtHeight.Text);
				if (iW <= 0 || iH <= 0)
					throw new System.Exception ();

				filelistgen.StartThread (new DirectoryInfo (this.txtSrcPath.Text), 
					dlgOptions.priority);
				convertors = new FileConvertor [dlgOptions.threads];
				for (int i = 0; i < convertors.Length; ++i)
				{
					convertors [i] = new FileConvertor
						("Convertor" + (i + 1).ToString (),
						buffer, this);
					convertors [i].StartThread (this.txtSrcPath.Text,
						this.txtDestPath.Text, iW, iH, dlgOptions.format,
						this.dlgOptions.qualitymode, dlgOptions.priority);
				}
				threadsRunning = convertors.Length + 1;
				tmrSeconds.Enabled = true;
				UpdateUI ();
			}
			catch
			{
				MessageBox.Show ("You must enter proper values for width and height\nProper values include positive integers.", "Error!");
			}
		}

		private void StopThreads ()
		{
			filelistgen.CancelThread ();
			foreach (FileConvertor convertor in convertors)
				convertor.CancelThread ();
			buffer.Clear();
		}

		private void btnSrcPathSel_Click (object sender, EventArgs e)
		{
			if (this.dlgSrcSel.ShowDialog () == DialogResult.OK)
			{
				this.txtSrcPath.Text = this.dlgSrcSel.SelectedPath;
			}
			else
			{
				this.dlgSrcSel.SelectedPath = this.txtSrcPath.Text;
			}
		}

		private void btnDestPathSel_Click (object sender, EventArgs e)
		{
			if (this.dlgDestSel.ShowDialog () == DialogResult.OK)
			{
				this.txtDestPath.Text = this.dlgDestSel.SelectedPath;
			}
			else
			{
				this.dlgDestSel.SelectedPath = this.txtDestPath.Text;
			}
		}

		private void btnOptions_Click (object sender, EventArgs e)
		{
			dlgOptions.ShowDialog ();
		}

		private void tmrSeconds_Tick (object sender, EventArgs e)
		{
			runTime = runTime.Add (new TimeSpan (0, 0, 1));
			UpdateUI ();
		}
	}
}
