using System;

namespace WheelOfLunch2
{
#if WINDOWS || XBOX
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main (string [] args)
		{
			using (WheelOfLunch2 game = new WheelOfLunch2 ())
			{
				game.Run ();
			}
		}
	}
#endif
}

