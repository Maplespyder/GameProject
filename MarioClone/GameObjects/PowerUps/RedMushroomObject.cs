﻿using MarioClone.Collision;
using MarioClone.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace MarioClone.GameObjects
{
	public class RedMushroomObject : AbstractPowerup
	{
        public const float GravityAcceleration = 0.4f;
        public bool Gravity { get; set; }
        public RedMushroomObject(ISprite sprite, Vector2 position) : base(sprite, position, Color.Green) { }

        public override bool CollisionResponse(AbstractGameObject gameObject, Side side, GameTime gameTime)
        {
            if (gameObject is Mario)
            {
                isCollided = true;
            }
            else if (gameObject is AbstractBlock)
            {
                if (side == Side.Bottom)
                {
                    Velocity = new Vector2(Velocity.X, 0);
                    Gravity = false;
                }
                else if (side == Side.Left)
                {
                    Velocity = new Vector2(2, Velocity.Y);
                }
                else if (side == Side.Right)
                {
                    Velocity = new Vector2(-2, Velocity.Y);
                }
            }

            return true;
        }

        public override bool Update(GameTime gameTime, float percent)
        {
            if (Gravity)
            {
                Velocity = new Vector2(Velocity.X, Velocity.Y + GravityAcceleration);
            }
            Gravity = true;
            return isCollided || base.Update(gameTime, percent);
        }

        public override void FixClipping(Vector2 correction)
        {
            Position = new Vector2(Position.X + correction.X, Position.Y + correction.Y);
            BoundingBox.UpdateHitBox(Position, Sprite);
        }

    }
}
