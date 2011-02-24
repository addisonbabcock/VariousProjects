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
	class WheelSegment : Microsoft.Xna.Framework.DrawableGameComponent
	{
		private float spinVelocity;
		private Vector2 center;
		private float angle;
		private SpriteBatch spriteBatch;
		private Texture2D texture;

		public WheelSegment (WheelOfLunch2 game)
			: base (game)
		{
			spinVelocity = 0.0f;
			center = new Vector2 ();
			angle = 0.0f;
			spriteBatch = new SpriteBatch (game.GraphicsDevice);
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

			texture = Game.Content.Load<Texture2D> ("pieslice");
		}

		public void RunLoadContent ()
		{
			LoadContent ();
		}
		
		public override void Draw (GameTime gameTime)
		{
			spriteBatch.Begin ();
		//	spriteBatch.Draw (texture, new Rectangle (0, 0, 100, 100), Color.Red);
			spriteBatch.Draw (
				texture, 
				Center, 
				null, 
				Color.Red, 
				(float)(Angle * Math.PI / 180.0f), 
				new Vector2 (texture.Width / 2, 0.0f), 
				0.25f, 
				SpriteEffects.None, 
				0.0f);
			spriteBatch.End ();

			base.Draw (gameTime);
		}

		public override void Update (GameTime gameTime)
		{
			base.Update (gameTime);
		}
	}
}
