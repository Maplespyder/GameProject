﻿using MarioClone.Collision;
using MarioClone.Sprites;
using MarioClone.States.EnemyStates;
using Microsoft.Xna.Framework;
using MarioClone.EventCenter;
using MarioClone.States;

namespace MarioClone.GameObjects
{
    public class GreenKoopaObject : AbstractEnemy
    {
        public GreenKoopaObject(ISprite sprite, Vector2 position) : base(sprite, position)
		{
            Gravity = false;
			BoundingBox.UpdateOffSets(-8, -8, -20, -1);
            BoundingBox.UpdateHitBox(Position, Sprite);

            Orientation = Facing.Left;
            PowerupState = new KoopaAlive(this);

            PointValue = 300;
        }

        public override bool CollisionResponse(AbstractGameObject gameObject, Side side, GameTime gameTime)
        {
            if (gameObject is Mario && !(((Mario)gameObject).PowerupState is MarioInvincibility2))
            {
                var mario = (Mario)gameObject;
                if (side.Equals(Side.Top))
                {
                    EventManager.Instance.TriggerEnemyDefeatedEvent(this, mario);
                    PowerupState.BecomeDead();
                    return true;
                }

            }
            else if (gameObject is AbstractBlock)
            {
                if (side == Side.Bottom)
                {
                    Gravity = false;
                    Velocity = new Vector2(Velocity.X, 0);
                    if (((AbstractBlock)gameObject).Bumper != null)
                    {
                        EventManager.Instance.TriggerEnemyDefeatedEvent(this, ((AbstractBlock)gameObject).Bumper);
                        PowerupState.BecomeDead();
                    }
                }
                else if (side == Side.Left)
                {
                    Velocity = new Vector2(EnemyHorizontalMovementSpeed, Velocity.Y);
                    Orientation = Facing.Right;
                }
                else if (side == Side.Right)
                {
                    Velocity = new Vector2(-EnemyHorizontalMovementSpeed, Velocity.Y);
                    Orientation = Facing.Left;
                }
            }else if(gameObject is FireBall)
			{
                var fireball = (FireBall)gameObject;
                if (fireball.Owner is Mario)
                {
                    EventManager.Instance.TriggerEnemyDefeatedEvent(this, (Mario)fireball.Owner);
                    PowerupState.BecomeDead();
                    return true;
                }
			}

            return false;
        }
        public override bool Update(GameTime gameTime, float percent)
        {
            bool retval = base.Update(gameTime, percent);

            if (Gravity)
            {
                Velocity = new Vector2(Velocity.X, Velocity.Y + Mario.GravityAcceleration * percent);
            }
            if (!(PowerupState is KoopaDead))
            {
                Gravity = true;
            }

            return retval;
        }
    }
}
