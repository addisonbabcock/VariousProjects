using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace TorrentSpammer
{
	enum TorrentState
	{
		Started,
		Stopped,
		Seeding
	}

	struct StartupArgs
	{
		public string StatusString { get; set; }
		public string TorrentName { get; set; }
	}

	class Program
	{
		static StartupArgs ParseStartupArgs (string [] args)
		{
			StartupArgs startupArgs = new StartupArgs ();

			startupArgs.TorrentName = args [0];
			startupArgs.StatusString = args [1];

			return startupArgs;
		}

		static void Main (string [] args)
		{
			StartupArgs startupArgs = ParseStartupArgs (args);

			string username = ConfigurationManager.AppSettings ["UserName"];
			string password = ConfigurationManager.AppSettings ["Password"];

			SmtpClient smtpClient = new SmtpClient ("smtp.gmail.com");
			smtpClient.Port = 587;
			smtpClient.Credentials = new NetworkCredential (username, password);
			smtpClient.EnableSsl = true;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

			try
			{
				smtpClient.Send (new MailMessage ("test@ohshit.endoftheinternet.org", "addison.babcock@gmail.com", "Test", "Testing"));
			}
			catch (Exception e)
			{
				Console.WriteLine ("Failed to send email: {0}", e.Message);
			}
		}
	}
}
