using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BattleOfLunchServer
{
	class AcceptThread
	{
		private Socket mListener;
		private Thread mThread;
		private SafeBuffer mCompleteConn;

		public AcceptThread ()
		{
			mCompleteConn = new SafeBuffer ();

			mListener = new Socket (AddressFamily.InterNetwork, SocketType.Stream,
				ProtocolType.Tcp);
			mListener.Bind (new IPEndPoint (IPAddress.Any, 56666));
			mListener.Listen (3);

			mThread = new Thread (new ThreadStart (ThreadHandler));
			mThread.Name = "Connection accepting thread";
			mThread.IsBackground = true;
			mThread.Start ();
		}

		public bool HasSockets ()
		{
			return mCompleteConn.Size () > 0;
		}

		public Socket GetSocket ()
		{
			if (!HasSockets ())
				return null;

			return (Socket)mCompleteConn.Buffer;
		}

		private void ThreadHandler ()
		{
			while (true)
			{
				Socket freshSocket = mListener.Accept ();

				mCompleteConn.Buffer = freshSocket;
			}
		}
	}
}
