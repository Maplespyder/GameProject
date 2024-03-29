﻿using MarioClone.EventCenter;
using MarioClone.GameObjects;
using Microsoft.Xna.Framework;

namespace MarioClone.States
{
    public class PowerupRevealState : PowerupState
    {
        private Vector2 initialPosition;
        private static Vector2 revealSpeed = new Vector2(0, -2);

        public PowerupRevealState(AbstractPowerup context) : base(context)
        {
            initialPosition = new Vector2(context.Position.X, context.Position.Y);
            context.Velocity = new Vector2(revealSpeed.X, revealSpeed.Y);
            context.DrawOrder = 0.53f;
        }

        public override bool Update(GameTime gameTime, float percent)
        {
            /*if(Context.Position.Y >= initialPosition.Y - Context.Sprite.SourceRectangle.Height)
            {
                Context.Position = new Vector2(Context.Position.X, Context.Position.Y + Context.Velocity.Y * percent);
            }*/

            if ((Context.Position.Y <= (initialPosition.Y - 64)) && percent != 0)
            {
                if(Context is CoinObject)
                {
                    EventManager.Instance.TriggerPowerupCollectedEvent(Context, Context.Releaser);
                    Context.PointValue = 0;
                    return true;
                }
                else if (Context is RedMushroomObject)
                {
                    Context.State = new MushroomMovingState(Context);
                }
                else if (Context is GreenMushroomObject)
                {
                    Context.State = new MushroomMovingState(Context);
                }
                else if (Context is FireFlowerObject)
                {
                    Context.State = new FireFlowerStaticState(Context);
                }
            }

            return false;
        }

        public override bool CollisionResponse(AbstractGameObject obj)
        {
            return false;
        }
    }
}
