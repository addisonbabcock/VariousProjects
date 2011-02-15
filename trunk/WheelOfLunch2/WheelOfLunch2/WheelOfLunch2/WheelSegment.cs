using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft;
using Microsoft.Xna;
using Microsoft.Xna.Framework;

namespace WheelOfLunch2
{
	class WheelSegment : Microsoft.Xna.Framework.DrawableGameComponent
	{
		private float spinVelocity;
		private Vector2 center;
		private float angle;

		public WheelSegment (WheelOfLunch2 game)
			: base (game)
		{
			spinVelocity = 0.0f;
			center = new Vector2 (game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2);
			angle = 0.0f;
		}

		public float SpinVelocity
		{
			get { return spinVelocity; }
			set { spinVelocity = value; }
		}

		public Vector2 Center
		{
			get { return center; }
			set { center = value; }
		}

		public float Angle
		{
			get { return angle; }
			set { angle = value; }
		}
		
		protected override void LoadContent ()
		{
			 base.LoadContent ();
		}

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);
		}

		public override void Update (GameTime gameTime)
		{
			base.Update (gameTime);
		}
	}
}
