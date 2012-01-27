using System;
using System.IO;
using System.Threading;
using System.Collections;

namespace ImageManipulator2
{
	public class FileListGenerator
	{
		private Thread generatorthread;
		private LockingBuffer<FileInfo> buffer;
		private DirectoryInfo basedir;
		private bool mbCancel;
		private MainForm mainForm;

		public FileListGenerator (LockingBuffer<FileInfo> listbuffer, MainForm form)
		{
			buffer = listbuffer;
			mainForm = form;
		}

		public void StartThread (DirectoryInfo dir, ThreadPriority priority)
		{
			mbCancel = false;
			basedir = dir;
			generatorthread = new Thread (Start);
			generatorthread.Name = "Generator";
			generatorthread.IsBackground = true;
			generatorthread.Priority = priority;
			generatorthread.Start ();
		}

		public void CancelThread ()
		{
			mbCancel = true;
		}

		private bool CheckCancel ()
		{
			if (mbCancel)
				return true;
			return false;
		}

		private void Start ()
		{
			ProcessDirectory (basedir);
			mainForm.ThreadEnded (generatorthread.Name);
		}

		private void ProcessDirectory (DirectoryInfo dir)
		{
			if (dir == null)
				return;

			mainForm.AddLogMsg ("Queueing " + dir.FullName);
			String lookfor = "*.jpg;*.jpeg;*.gif;*.png;*.bmp";
			String [] extensions = lookfor.Split (new char [] { ';' });

			try
			{
				DirectoryInfo[] subDirs = dir.GetDirectories();
				foreach (DirectoryInfo subDir in subDirs)
				{
					if (CheckCancel())
						return;

					ProcessDirectory(subDir);
				}
			}
			catch (Exception)
			{
				return;
			}

			ArrayList files = new ArrayList ();
			foreach (String ext in extensions)
			{
				if (CheckCancel ())
					return;

				files.AddRange (dir.GetFiles (ext));
			}

			foreach (FileInfo file in files)
			{
				if (CheckCancel ())
					return;

				mainForm.AddLogMsg ("Queueing file " + file.FullName);
				mainForm.IncQueueSize ();
				buffer.Buffer = file;
			}
		}

		public bool ThreadRunning ()
		{
			if (generatorthread != null)
				return generatorthread.IsAlive;
			else
				return false;
		}
	}
}