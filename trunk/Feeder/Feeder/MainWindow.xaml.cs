using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.IO;
using System.Net;

namespace Feeder
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow ()
		{
			InitializeComponent ();
		}

		private void button1_Click (object sender, RoutedEventArgs e)
		{
			WebRequest request = WebRequest.Create ("http://feeds2.feedburner.com/AndroidPhoneFans");
			WebResponse response = request.GetResponse ();


			XmlNode rssNode = null;
			XmlNode channelNode = null;

			XmlDocument rss = new XmlDocument ();
			rss.Load (response.GetResponseStream ());
			foreach (XmlNode childNode in rss.ChildNodes)
			{
				if (childNode.Name == "rss")
				{
					rssNode = childNode;
				}
			}

			if (rssNode == null)
				return;

			foreach (XmlNode childNode in rssNode)
			{
				if (childNode.Name == "channel")
				{
					channelNode = childNode;
				}
			}

			if (channelNode == null)
				return;
		}
	}
}
