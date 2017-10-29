﻿using MarioClone.Sprites;
using Microsoft.Xna.Framework;
using MarioClone.States;
using MarioClone.Collision;

namespace MarioClone.GameObjects
{
    public class AbstractPowerup : AbstractGameObject
    {
        public PowerupState State { get; set; }
        public bool isCollided { get; set; }

        public AbstractPowerup(ISprite sprite, Vector2 position, Color hitboxColor) : base(sprite, position, hitboxColor)
        {
            State = new PowerupRevealState(this);
        }

        public override bool Update(GameTime gameTime, float percent)
        {
            bool retval = State.Update(gameTime, percent);
            Position = new Vector2((percent * Velocity.X) + Position.X, (percent * Velocity.Y) + Position.Y);

            return base.Update(gameTime, percent) || retval;
        }

        public override bool CollisionResponse(AbstractGameObject gameObject, Side side, GameTime gameTime)
        {
            return State.CollisionResponse(gameObject);
        }
    }
}