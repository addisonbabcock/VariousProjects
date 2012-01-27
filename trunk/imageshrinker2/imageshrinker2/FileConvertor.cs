using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageManipulator2
{
	public class FileConvertor
	{
		private Thread convertThread;
		private LockingBuffer<FileInfo> listBuffer;
		private String threadName;
		private MainForm mainForm;
		private String srcPath;
		private String destPath;
		private int destH;
		private int destW;
		private bool cancel;
		private ImageFormat convertFormat;
		private bool qualityMode;

		public FileConvertor (String name, LockingBuffer<FileInfo> list, MainForm form)
		{
			listBuffer = list;
			threadName = name;
			mainForm = form;
		}

		public void StartThread (String sourcePath, String destinationPath,
			int destinationW, int destinationH, ImageFormat format,
			bool QualityMode, ThreadPriority priority)
		{
			convertThread = new Thread (Start);
			convertThread.Name = threadName;
			convertThread.IsBackground = true;
			convertThread.Priority = priority;
			convertThread.Start ();
			srcPath = sourcePath;
			destPath = destinationPath;
			destH = destinationH;
			destW = destinationW;
			cancel = false;
			convertFormat = format;
			qualityMode = QualityMode;
		}

		private void Start ()
		{
			FileInfo file = listBuffer.Buffer;

			while (file != null && !cancel)
			{
				mainForm.AddLogMsg (
					convertThread.Name + " Processing " + file.FullName);

				String newPath = file.DirectoryName;
				newPath = newPath.Remove (0, srcPath.Length);
				newPath = newPath.Insert (0, destPath);
				if (!Directory.Exists (newPath))
					Directory.CreateDirectory (newPath);
				newPath += "\\" + file.Name;
				newPath = newPath.Remove (newPath.LastIndexOf ('.'));
				if (convertFormat == ImageFormat.Bmp)
					newPath = newPath.Insert (newPath.Length, ".bmp");
				if (convertFormat == ImageFormat.Gif)
					newPath = newPath.Insert (newPath.Length, ".gif");
				if (convertFormat == ImageFormat.Jpeg)
					newPath = newPath.Insert (newPath.Length, ".jpg");
				if (convertFormat == ImageFormat.Png)
					newPath = newPath.Insert (newPath.Length, ".png");

				FileStream newFile = new FileStream (newPath, FileMode.OpenOrCreate);
				Image image = System.Drawing.Image.FromFile (file.FullName);

				if (!qualityMode)
				{
					Image thumb =
						image.GetThumbnailImage (destW, destH, CheckCancel, IntPtr.Zero);
					thumb.Save (newFile, convertFormat);
				}
				else
				{
					Bitmap oldBitmap = new Bitmap (image);
					Bitmap newBitmap = new Bitmap (destW, destH);

					int iOldXA = 0, iOldYA = 0,
						iOldXB = 0, iOldYB = 0,
						iNewX = 0, iNewY = 0;
					float fAlpha = 0.0f, fBeta = 0.0f;
					Color A, B, C, D, E, F, X;
					for (iNewX = 0; iNewX < destW; ++iNewX)
					{
						for (iNewY = 0; iNewY < destH; ++iNewY)
						{
							iOldXA = (int)(((float)image.Size.Width) / ((float)destW) * (float)iNewX - 0.5f);
							iOldYA = (int)(((float)image.Size.Height) / ((float)destH) * (float)iNewY - 0.5f);
							iOldXB = (int)(((float)image.Size.Width) / ((float)destW) * (float)iNewX + 0.5f);
							iOldYA = (int)(((float)image.Size.Height) / ((float)destH) * (float)iNewY + 0.5f);


							A = oldBitmap.GetPixel (iOldXA, iOldYA);
							B = oldBitmap.GetPixel (iOldXB, iOldYA);
							C = oldBitmap.GetPixel (iOldXA, iOldYB);
							D = oldBitmap.GetPixel (iOldXB, iOldYB);

							E = Color.FromArgb (
								(int)(A.R + fAlpha * (B.R - A.R)),
								(int)(A.G + fAlpha * (B.G - A.G)),
								(int)(A.B + fAlpha * (B.B - A.B)));
							F = Color.FromArgb (
								(int)(C.R + fAlpha * (D.R - C.R)),
								(int)(C.G + fAlpha * (D.G - C.G)),
								(int)(C.B + fAlpha * (D.B - C.B)));
							X = Color.FromArgb (
								(int)(E.R + fBeta * (F.R - E.R)),
								(int)(E.G + fBeta * (F.G - E.G)),
								(int)(E.B + fBeta * (F.B - E.B)));
							newBitmap.SetPixel (iNewX, iNewY, X);
						}
						if (CheckCancel ())
						{
							newFile.Close ();
							//System.GC.Collect ();
							mainForm.ThreadEnded (convertThread.Name);
							return;
						}
					}
					newBitmap.Save (newFile, convertFormat);
				}

				mainForm.IncProcessedSize ();

				file = listBuffer.Buffer;
				//System.GC.Collect ();
			}
			mainForm.ThreadEnded (convertThread.Name);
		}

		public bool ThreadRunning ()
		{
			if (convertThread != null)
				return convertThread.IsAlive;
			else
				return false;
		}

		public bool CheckCancel ()
		{
			return cancel;
		}

		public void CancelThread ()
		{
			cancel = true;
		}
	}
}
