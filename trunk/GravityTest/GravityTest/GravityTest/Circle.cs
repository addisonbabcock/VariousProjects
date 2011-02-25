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
			spriteBatch.Draw (circleImage, currentPosition, Color.White);
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

			float frameTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			timePassed += frameTime;
			velocity += acceleration * frameTime;
			currentPosition += velocity * frameTime;
		}

		private Vector2 currentPosition;
		private float timePassed;
		private Vector2 acceleration;
		private Vector2 velocity;

		public void Start ()
		{
			currentPosition = StartingPosition;
			acceleration = new Vector2 (0.0f, -9.81f);
			velocity = new Vector2 ();

			velocity.X = (EndingPosition.X - StartingPosition.X) * Time;
			velocity.Y = -acceleration.Y * Time;
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
