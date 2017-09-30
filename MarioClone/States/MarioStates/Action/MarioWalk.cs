﻿using MarioClone.GameObjects;
using MarioClone.Factories;
using System;

namespace MarioClone.States
{
    public class MarioWalk : MarioActionState
    {
        static MarioWalk _state;

        private MarioWalk(Mario context) : base(context)
        {
            Action = MarioAction.Walk;
        }

        public static MarioActionState Instance
        {
            get
            {
                if (_state == null)
                {
                    _state = new MarioWalk(Mario.Instance);
                }
                return _state;
            }
        }

        public override void BecomeCrouch()
        {
            Context.ActionState = MarioCrouch.Instance;
            Context.PreviousActionState = this;
            Context.Sprite = Context.SpriteFactory.Create(MarioAction.Crouch);
        }

        public override void BecomeJump()
        {
            Context.ActionState = MarioJump.Instance;
            Context.PreviousActionState = this;
            Context.Sprite = Context.SpriteFactory.Create(MarioAction.Jump);
        }

        public override void UpdateHitBox()
        {
            if (Context.PowerupState.Powerup == MarioPowerupState.MarioPowerup.Normal)
            {
                if (Context.Orientation.Equals(Facing.Left)) Context.BoundingBox.UpdateOffSets(0, -8, 0, 0);
                if (Context.Orientation.Equals(Facing.Right)) Context.BoundingBox.UpdateOffSets(-8, 0, 0, 0);
            }
            else if (Context.PowerupState.Powerup == MarioPowerupState.MarioPowerup.Super || Context.PowerupState.Powerup == MarioPowerupState.MarioPowerup.Fire)
            {
                Context.BoundingBox.UpdateOffSets(-10, -10, -10, 0);
            }
        }

        public override void BecomeWalk(Facing orientation)
        {
            if (Context.Orientation != orientation)
            {
                Context.ActionState = MarioIdle.Instance;
                Context.PreviousActionState = this;
                Context.Sprite = Context.SpriteFactory.Create(MarioAction.Idle);
            }
        }
    }
}
