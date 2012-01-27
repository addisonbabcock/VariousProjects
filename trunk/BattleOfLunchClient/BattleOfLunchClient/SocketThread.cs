using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace BattleOfLunchClient
{
	class SocketThread
	{
		private SafeBuffer mBuffer;
		private Socket mSocket;
		private Thread mThread;
		private bool mIsConnected;

		public SocketThread ()
		{
			mBuffer = new SafeBuffer ();
			mSocket = new Socket (AddressFamily.InterNetwork, 
				SocketType.Stream, ProtocolType.Tcp);
			mThread = null;
			mIsConnected = false;
		}

		public void Connect (IPAddress addr)
		{
			if (mThread == null)
			{
				mThread = new Thread (new ParameterizedThreadStart (ThreadHandler));
				mThread.Name = "Client socket thread";
				mThread.IsBackground = true;
				mThread.Start (addr);
			}
			else
			{
				MessageBox.Show ("Socket already connected.", "Error");
			}
		}

		public bool IsConnected ()
		{
			return mIsConnected;
		}

		private void ThreadHandler (Object param)
		{
			IPAddress addr = (IPAddress)param;

			try
			{
				mSocket.Connect (addr, 56666);
				mIsConnected = true;
			}
			catch (SocketException ex)
			{
				MessageBox.Show (ex.Message, "Socket exception occured");
				return;
			}
		}
	}
}
