﻿using MarioClone.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioClone.Sprites
{
	public abstract class Sprite : ISprite
	{

        #region Properties

        public Rectangle SourceRectangle { get; protected set; }

		public Texture2D SpriteSheet { get; protected set; }
		public bool Finished { get; protected set; }

		#endregion

		protected Sprite(Texture2D spriteSheet, Rectangle sourceRectangle)
        {
			SpriteSheet = spriteSheet;
            SourceRectangle = sourceRectangle;
        }

        #region ISprite

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 Position, float LayerDepth, GameTime gameTime, Facing facing, float scaling = 1)
		{
            SpriteEffects flip = (facing == Facing.Right) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(SpriteSheet, new Vector2((int)Position.X, (int)Position.Y - SourceRectangle.Height), SourceRectangle, Color.White, 0, 
				Vector2.Zero, scaling, flip, LayerDepth);
		}

		public virtual void Draw(SpriteBatch spriteBatch, Vector2 Position, float LayerDepth, GameTime gameTime, Facing facing, Color color, float scaling = 1)
		{
			SpriteEffects flip = (facing == Facing.Right) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(SpriteSheet, new Vector2((int)Position.X, (int)Position.Y - SourceRectangle.Height), SourceRectangle, color, 0,
				Vector2.Zero, scaling, flip, LayerDepth);
		}

		#endregion

	}
}
