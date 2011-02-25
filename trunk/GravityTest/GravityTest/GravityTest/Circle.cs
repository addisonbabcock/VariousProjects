using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravityTest
{
	class Circle : Microsoft.Xna.Framework.DrawableGameComponent
	{
		private Texture2D circleImage;
		private SpriteBatch spriteBatch;

		public Circle (Game game)
			: base (game)
		{
		}

		public override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);

			spriteBatch.Begin ();
			spriteBatch.Draw (circleImage, new Vector2 (0, 0), Color.White);
			spriteBatch.End ();
		}

		public void DoLoadContent ()
		{
			LoadContent ();
		}

		protected override void LoadContent ()
		{
			base.LoadContent ();
			spriteBatch = new SpriteBatch (Game.GraphicsDevice);
			circleImage = Game.Content.Load<Texture2D> ("circle");
		}

		public override void Update (GameTime gameTime)
		{
			base.Update (gameTime);
		}

		public Vector2 StartingPosition
		{
			get;
			set;
		}

		public Vector2 EndingPosition
		{
			get;
			set;
		}

		public float Time
		{
			get;
			set;
		}
	}
}
