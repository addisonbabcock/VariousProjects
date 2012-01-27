using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WheelOfLunch
{
	public partial class frmRestaurants : Form
	{
		private const int maxRestaurants = 32;
		private System.Windows.Forms.TextBox [] restaurants = new TextBox [maxRestaurants];
		private System.Windows.Forms.CheckBox [] liststatus = new CheckBox [maxRestaurants];
		private bool mLoaded = false;

		public bool IsLoaded
		{
			get
			{
				return mLoaded;
			}
		}

		public frmRestaurants ()
		{
			InitializeComponent ();

			for (int i = 0; i < maxRestaurants; ++i)
			{
				restaurants [i] = new TextBox ();
				grpBox.Controls.Add (restaurants [i]);
				if (i < 16)
					restaurants [i].Location = new Point (6, 42 + i * 26);
				else
					restaurants [i].Location = new Point (243, 42 + (i - 16) * 26);
				restaurants [i].Name = "restaurants [" + i.ToString () + "]";
				restaurants [i].Size = new Size (100, 20);
				restaurants [i].TabIndex = i * 2;

				liststatus [i] = new CheckBox ();
				grpBox.Controls.Add (liststatus [i]);
				if (i < 16)
					liststatus [i].Location = new Point (112, 44 + i * 26);
				else
					liststatus [i].Location = new Point (349, 44 + (i - 16) * 26);
				liststatus [i].AutoSize = true;
				liststatus [i].Name = "liststatus [" + i.ToString () + "]";
				liststatus [i].Size = new Size (100, 17);
				liststatus [i].TabIndex = i * 2 + 1;
				liststatus [i].UseVisualStyleBackColor = true;
				liststatus [i].CheckedChanged += new EventHandler (CheckedChanged);
			}

			LoadFile ();
		}

		private void LoadFile ()
		{
			try
			{
//				StreamReader sr = new StreamReader ("S:\\Addison\\RestaurantList.txt");
				StreamReader sr = new StreamReader (filename.Text);
				int i = 0;
				do
				{
					restaurants [i].Text = sr.ReadLine ();
					liststatus [i].Checked = sr.ReadLine ().CompareTo ("True") == 0;
					++i;
				} while (!sr.EndOfStream && i < maxRestaurants);
				sr.Close ();
				mLoaded = true;
			}
			catch (FileNotFoundException ex)
			{
				MessageBox.Show ("Failed to read in file, " + ex.Message);
				mLoaded = false;
			}
			catch (Exception ex)
			{
				Console.WriteLine (ex.Message);
				//ignore...
			}

			GC.Collect ();

			UpdateListStatus ();
		}

		private void UpdateListStatus ()
		{
			for (int i = 0; i < maxRestaurants; ++i)
			{
				if (liststatus [i].Checked)
				{
					liststatus [i].Text = "On the list";
					liststatus [i].ForeColor = Color.Green;
				}
				else
				{
					liststatus [i].Text = "OFF THE LIST";
					liststatus [i].ForeColor = Color.Red;
				}
			}
		}

		private void btnClose_Click (object sender, EventArgs e)
		{
			if (restaurantCount < 3)
			{
				MessageBox.Show ("You need at least 3 restaurants.");
				return;
			}

			for (int i = 0; i < maxRestaurants; ++i)
			{
				if (liststatus [i].Checked && restaurants [i].Text.Length == 0)
				{
					MessageBox.Show ("Empty restaurant names are not allowed.");
					return;
				}
			}

//			StreamWriter sw = new StreamWriter ("S:\\Addison\\RestaurantList.txt");
			try
			{
				StreamWriter sw = new StreamWriter (filename.Text);
				for (int i = 0; i < maxRestaurants; ++i)
				{
					sw.WriteLine (restaurantName (i));
					sw.WriteLine (liststatus [i].Checked);
				}
				sw.WriteLine ();
				sw.Close ();
			}
			catch (Exception ex)
			{
				Console.WriteLine (ex.Message);
				//ignore...
			}
			Close ();
		}

		public int restaurantCount
		{
			get
			{
				int count = 0;
				for (int i = 0; i < maxRestaurants; ++i)
				{
					if (liststatus [i].Checked)
						++count;
				}
				return count;
			}
		}

		public string restaurantName (int num)
		{
			return restaurants [num].Text;
		}

		public string [] restaurantNames
		{
			get
			{
				string [] ret = new string [restaurantCount];
				int retIndex = 0;
				int restaurantIndex = 0;

				for (; restaurantIndex < maxRestaurants; ++restaurantIndex)
				{
					if (liststatus [restaurantIndex].Checked)
						ret [retIndex++] = restaurantName (restaurantIndex);
				}

				return ret;
			}
		}

		private void CheckedChanged (Object obj, System.EventArgs e)
		{
			UpdateListStatus ();
		}

		private void btnLoad_Click (object sender, EventArgs e)
		{
			LoadFile ();
		}
	}
}