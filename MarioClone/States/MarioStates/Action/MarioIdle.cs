using MarioClone.GameObjects;
using MarioClone.Factories;
using System;
using static MarioClone.States.MarioPowerupState;

namespace MarioClone.States
{
    public class MarioIdle : MarioActionState
    {
        static MarioIdle _state;

        private MarioIdle(Mario context) : base(context)
        {
            Action = MarioAction.Idle;
        }

        public static MarioActionState Instance
        {
            get
            {
                if (_state == null)
                {
                    _state = new MarioIdle(Mario.Instance);
                }
                return _state;
            }
        }

        public override void BecomeCrouch()
        {
            if (Context.PowerupState.Powerup == MarioPowerup.Super || Context.PowerupState.Powerup == MarioPowerup.Fire)
            {
                Context.ActionState = MarioCrouch.Instance;
                Context.PreviousActionState = this;
                Context.Sprite = Context.SpriteFactory.Create(MarioAction.Crouch);
            }
        }
        public override void UpdateHitBox()
        {
            if (Context.PowerupState.Powerup == MarioPowerupState.MarioPowerup.Normal)
            {
               if(Context.Orientation.Equals(Facing.Left)) Context.BoundingBox.UpdateOffSets(0, -8, 0, 0);
                if (Context.Orientation.Equals(Facing.Right)) Context.BoundingBox.UpdateOffSets(-8, 0, 0, 0);
            }
            else if (Context.PowerupState.Powerup == MarioPowerupState.MarioPowerup.Super || Context.PowerupState.Powerup == MarioPowerupState.MarioPowerup.Fire)
            {
                Context.BoundingBox.UpdateOffSets(-10, -10, -10, 0);
            }
        }

        public override void BecomeJump()
        {
            Context.ActionState = MarioJump.Instance;
            Context.PreviousActionState = this;
            Context.Sprite = Context.SpriteFactory.Create(MarioAction.Jump);
        }

        public override void BecomeWalk(Facing orientation)
        {
            if (Context.Orientation == orientation)
            {
                Context.ActionState = MarioWalk.Instance;
                Context.PreviousActionState = this;
                Context.Sprite = Context.SpriteFactory.Create(MarioAction.Walk);
            }
            else
            {
                Context.Orientation = orientation;
            }
        }
    }
}
