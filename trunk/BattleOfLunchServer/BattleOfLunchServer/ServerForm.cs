using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace BattleOfLunchServer
{
	public partial class ServerForm : Form
	{
		private AcceptThread mAcceptor;
		private System.Collections.Generic.LinkedList<Player> mPlayers;

		public ServerForm ()
		{
			InitializeComponent ();

			mAcceptor = new AcceptThread ();
			mPlayers = new LinkedList<Player> ();

			MainTimer.Start ();
		}

		private void ServerForm_Load (object sender, EventArgs e)
		{

		}

		private void MainTimer_Tick (object sender, EventArgs e)
		{
			while (mAcceptor.HasSockets ())
			{
				ProcessNewSocket ();
			}
		}

		private void ProcessNewSocket ()
		{
			Socket freshSocket = mAcceptor.GetSocket ();

			Console.WriteLine ("Got a new socket!");

			Player newPlayer = new Player (mPlayers.Count, freshSocket);

			mPlayers.AddLast (newPlayer);
		}
	}
}