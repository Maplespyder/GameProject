﻿using MarioClone.GameObjects;
using MarioClone.Factories;
using System;
using Microsoft.Xna.Framework;

namespace MarioClone.States
{
    public class MarioJump : MarioActionState
    {
        static MarioJump _state;

        private MarioJump(Mario context) : base(context)
        {
            Action = MarioAction.Jump;
        }

        public static MarioActionState Instance
        {
            get
            {
                if (_state == null)
                {
                    _state = new MarioJump(Mario.Instance);
                }
                return _state;
            }
        }

        public override void UpdateHitBox()
        {
            if (Context.PowerupState is MarioNormal)
            {
                Context.BoundingBox.UpdateOffSets(-8, -8, -4, 0);
            }
            else if (Context.PowerupState is MarioSuper || Context.PowerupState is MarioFire)
            {
                if (Context.Orientation.Equals(Facing.Left)) Context.BoundingBox.UpdateOffSets(-20, -20, -20, 0);
                if (Context.Orientation.Equals(Facing.Right)) Context.BoundingBox.UpdateOffSets(-20, -20, -20, 0);
            }
        }

        public override void Walk(Facing orientation)
        {
            Context.Velocity = orientation == Facing.Left ? new Vector2(-Mario.HorizontalMovementSpeed, Context.Velocity.Y) : new Vector2(Mario.HorizontalMovementSpeed, Context.Velocity.Y);
        }

        public override void ReleaseWalk(Facing orientation)
        {
            if (orientation == Facing.Left && Context.Velocity.X < 0 || orientation == Facing.Right && Context.Velocity.X > 0)
            {
                Context.Velocity = new Vector2(0, Context.Velocity.Y);
            }            
        }
    }
}
