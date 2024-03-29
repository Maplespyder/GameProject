﻿using MarioClone.Collision;
using MarioClone.EventCenter;
using MarioClone.GameObjects;
using Microsoft.Xna.Framework;

namespace MarioClone.States
{
    public class MarioDead2 : MarioPowerupState
    {
        private int deadDuration;

        public MarioDead2(Mario context) : base(context)
        {
            Powerup = MarioPowerup.Dead;
        }

        public override void Enter()
        {
            deadDuration = 0;
            Context.SpriteFactory = Factories.DeadMarioSpriteFactory.Instance;
            Context.StateMachine.TransitionIdle();
            Context.Gravity = false;
            Context.Lives--;
        }

        public override void BecomeDead() { }

        public override void BecomeNormal()
        {
            Context.StateMachine.TransitionNormal();
        }

        public override void BecomeSuper()
        {
            Context.StateMachine.TransitionSuper();
        }

        public override void BecomeFire()
        {
            Context.StateMachine.TransitionFire();
        }


        public override void TakeDamage(AbstractGameObject obj) { }
        
        public override void BecomeInvincible() { }

        public override void Update(GameTime gameTime)
        {
            deadDuration += gameTime.ElapsedGameTime.Milliseconds;
            if (deadDuration >= 3000)
            {
                EventManager.Instance.TriggerPlayerDiedEvent(Context);
            }
        }

        public override bool CollisionResponse(AbstractGameObject gameObject, Side side, GameTime gameTime)
        {
            return false;
        }
    }
}
