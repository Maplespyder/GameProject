﻿using MarioClone.GameObjects;
using MarioClone.Factories;
using Microsoft.Xna.Framework;
using MarioClone.Collision;
using MarioClone.Sounds;
using MarioClone.EventCenter;

namespace MarioClone.States.BlockStates
{
    public class QuestionBlockAction : BlockState
    {
        private Vector2 initialPosition;

        //TODO tell powerup what mario hit it
        public QuestionBlockAction(AbstractBlock context, Mario bumper) : base(context)
        {
            initialPosition = context.Position;
			Context.Velocity = new Vector2(0f, -1f);
            Context.Bumper = bumper;

            EventManager.Instance.TriggerBrickBumpedEvent(Context, Context.ContainedPowerup, false);

			if (Context.ContainedPowerup != PowerUpType.None)
            {
                //do some powerup reveal related thing
                var powerup = PowerUpFactory.Create(Context.ContainedPowerup, Context.Position);
                powerup.Releaser = bumper;
                GameGrid.Instance.Add(powerup);
                Context.ContainedPowerup = PowerUpType.None;
            }
        }
        
        public override bool Action(float percent, GameTime gameTime)
        {
            if (Context.Position.Y >= (initialPosition.Y - 10)) //if Position hasnt reached max height
            {
                Context.Position = new Vector2(Context.Position.X, Context.Position.Y + Context.Velocity.Y * percent);
                if (Context.Position.Y <= (initialPosition.Y - 10))
                {
					Context.Velocity = new Vector2(0f, 1f);
                }
            }
            else
            {
                Context.Position = new Vector2(Context.Position.X, Context.Position.Y + Context.Velocity.Y * percent);
                Context.Velocity = new Vector2(0f, 1f);
            }

            if (Context.Position.Y >= initialPosition.Y && percent != 0) //back to static position
            {
				Context.Position = initialPosition;
                Context.Velocity = new Vector2(0, 0);
                Context.State = new Used(Context);
            }
            return false;
        }
    }
}
