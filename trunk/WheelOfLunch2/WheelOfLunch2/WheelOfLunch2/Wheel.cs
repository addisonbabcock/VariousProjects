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

		}

		protected override void LoadContent ()
		{
			base.LoadContent ();

			int maxSegments = 7;
			for (int i = 0; i < maxSegments; ++i)
			{
				WheelSegment segment = new WheelSegment ((WheelOfLunch2)Game);
				segment.Center = new Vector2 (Game.GraphicsDevice.Viewport.Width / 2, Game.GraphicsDevice.Viewport.Height / 2);
				segment.Angle = i * 360 / maxSegments;
				wheelSegments.Add (segment);
			}

			foreach (WheelSegment segment in wheelSegments)
				segment.RunLoadContent ();
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
