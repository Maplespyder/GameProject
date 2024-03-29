﻿using MarioClone.Collision;
using MarioClone.EventCenter;
using MarioClone.Factories;
using MarioClone.GameObjects;
using MarioClone.Sounds;
using Microsoft.Xna.Framework;

namespace MarioClone.States.BlockStates
{
    public class BreakableBrickBounce : BlockState
    {
        private Vector2 initialPosition;
        private bool GoToUsed = false;

        public BreakableBrickBounce(AbstractBlock context, Mario bumper) : base(context)
        {
            initialPosition = Context.Position;
			Context.Velocity = new Vector2(0f, -1f);
            Context.Bumper = bumper;

            EventManager.Instance.TriggerBrickBumpedEvent(Context, Context.ContainedPowerup, false);

			if (Context.CoinCount > 0)
            {
				Context.CoinCount -= 1;

                var coin = PowerUpFactory.Create(PowerUpType.Coin, Context.Position);
                coin.Releaser = bumper;
                GameGrid.Instance.Add(coin);

                if(Context.CoinCount == 0 && Context.ContainedPowerup == PowerUpType.None)
                {
                    GoToUsed = true;
                }
            }
            else if(Context.ContainedPowerup != PowerUpType.None)
            {
                //do some powerup reveal related thing
                var powerup = PowerUpFactory.Create(Context.ContainedPowerup, Context.Position);
                powerup.Releaser = bumper;
				GameGrid.Instance.Add(powerup);
                
                Context.ContainedPowerup = PowerUpType.None;
                GoToUsed = true;
            }
            else if(Context.CoinCount == 0 && Context.ContainedPowerup == PowerUpType.None)
            {
                GoToUsed = true;
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
                Context.Velocity = new Vector2(0f, 1f);
                Context.Position = new Vector2(Context.Position.X, Context.Position.Y + Context.Velocity.Y * percent);
            }

            if (Context.Position.Y >= initialPosition.Y && percent != 0) //back to static position
            {
				Context.Position = initialPosition;
                Context.Velocity = new Vector2(0, 0);

               if (GoToUsed)
                {
                    Context.State = new Used(Context);
                }
                else
                {
                    Context.State = new BreakableBrickStatic(Context);
                }
            }

            return false;
        }
    }
}
