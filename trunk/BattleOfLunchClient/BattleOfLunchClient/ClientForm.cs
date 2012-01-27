using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace BattleOfLunchClient
{
	public partial class ClientForm : Form
	{
		private SocketThread mSocket;

		public ClientForm ()
		{
			InitializeComponent ();

			mSocket = new SocketThread ();
		}

		private void Connect_Click (object sender, EventArgs e)
		{
			IPAddress addr = IPAddress.Parse (mIPAddress.Text);
			mSocket.Connect (addr);
		}
	}
}