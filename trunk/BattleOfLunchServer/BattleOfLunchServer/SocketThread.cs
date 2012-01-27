using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace BattleOfLunchServer
{
	class SocketThread
	{
		private Thread mThread;
		private Socket mSocket;
		private SafeBuffer mCompletedMessages;
		private SafeBuffer mOutboundMessages;
		private List<char> mPartialMessage;

		public SocketThread (Socket socket)
		{
			mSocket = socket;

			mCompletedMessages = new SafeBuffer ();
			mOutboundMessages = new SafeBuffer ();
			mPartialMessage = new List<char> ();

			mThread = new Thread (ThreadHandler);
			mThread.IsBackground = true;
			mThread.Name = "Socket Thread";
			mThread.Start ();
		}

		public void QueueMessage (List<char> message)
		{
			mOutboundMessages.Buffer = message;
		}

		public bool HasMessages ()
		{
			return mCompletedMessages.Size () != 0;
		}

		public List<char> GetMessage ()
		{
			if (!HasMessages ())
				return null;
			return (List<char>)mCompletedMessages.Buffer;
		}

		private void ThreadHandler ()
		{
		}
	}
}
