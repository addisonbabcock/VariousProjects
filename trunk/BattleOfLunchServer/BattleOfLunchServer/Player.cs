using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;


namespace BattleOfLunchServer
{
	class Player
	{
		private int mPlayerNo;
		private SocketThread mSocket;

		public Player (int playerNo, Socket socket)
		{
		//	mSocket = socket;
			mPlayerNo = playerNo;
			mSocket = new SocketThread (socket);
		}
	}
}
