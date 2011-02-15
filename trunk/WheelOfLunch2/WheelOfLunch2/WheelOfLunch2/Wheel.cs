using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WheelOfLunch2
{
	class Wheel : DrawableGameComponent
	{
		List<WheelSegment> wheelSegments;

		public Wheel (WheelOfLunch2 game)
			: base (game)
		{
			wheelSegments = new List<WheelSegment> ();

			for (int i = 0; i < 10; ++i)
			{
				WheelSegment segment = new WheelSegment (game);
				segment.Center = new Vector2 (game.GraphicsDevice.Viewport.X / 2, game.GraphicsDevice.Viewport.Y / 2);
				segment.Angle = i * 36;
				wheelSegments.Add (segment);
			}
		}

		protected override void LoadContent ()
		{
			base.LoadContent ();
		}

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);

			foreach (WheelSegment segment in wheelSegments)
				segment.Draw (gameTime);
		}

		public override void Update (GameTime gameTime)
		{
			base.Update (gameTime);

			foreach (WheelSegment segment in wheelSegments)
				segment.Update (gameTime);
		}
	}
}
