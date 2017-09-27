﻿using MarioClone.Factories;
using MarioClone.Sprites;
using MarioClone.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarioClone.States.MarioActionState;

namespace MarioClone.GameObjects
{
    public class Mario : IGameObject, IMoveable
    {
        private static Mario _mario;

        /// <summary>
        /// Do not instantiate Mario more than once. We have to make Mario before
        /// things that reference him use him, because I can't null check this getter.
        /// If you aren't sure what you're doing comes after Mario's creation, then
        /// null check the return on instance.
        /// </summary>
        public static Mario Instance
        {
            get
            {
                return _mario;
            }
        }

        public MarioActionState ActionState { get; set; }

        public MarioActionState PreviousActionState { get; set; }

        public MarioPowerupState PowerupState { get; set; }

        public ISprite Sprite { get; set; }

        public MarioSpriteFactory SpriteFactory { get; set; }

        public Vector2 Position { get; protected set; }

        public int DrawOrder { get; protected set; }

        public bool Visible { get; protected set; }

        public Vector2 Velocity { get; protected set; }

        public Facing Orientation { get; set; }

        /// <summary>
        /// This constructor should only ever be called by the Mario factory.
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="position"></param>
        public Mario(Vector2 velocity, Vector2 position)
        {
            _mario = this;
            PowerupState = MarioNormal.Instance;
            ActionState = MarioIdle.Instance;
            PreviousActionState = MarioIdle.Instance;
            Orientation = Facing.Right;
            SpriteFactory = NormalMarioSpriteFactory.Instance;
            Sprite = SpriteFactory.Create(MarioAction.Idle);
            Velocity = velocity;
            Position = position;
            Visible = true;
            DrawOrder = 1;
        }

		public void MoveLeft()
		{
			ActionState.BecomeWalk(Facing.Left);
		}

        public void MoveRight()
        {
            ActionState.BecomeWalk(Facing.Right);
        }

		public void BecomeJump()
        {
            ActionState.BecomeJump();
        }

        public void BecomeCrouch()
        {
            ActionState.BecomeCrouch();
        }

        public void BecomeDead()
        {
            PowerupState.BecomeDead();
        }

        public void BecomeNormal()
        {
            PowerupState.BecomeNormal();
        }

        public void BecomeSuper()
        {
            PowerupState.BecomeSuper();
        }

        public void BecomeFire()
        {
            PowerupState.BecomeFire();
        }

        public bool Update(GameTime gameTime)
        {
            Position = new Vector2(Position.X + Velocity.X, Position.Y + Velocity.Y);
            return false;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Visible)
            {
                Sprite.Draw(spriteBatch, Position, this.DrawOrder, gameTime, Orientation);
            }           
        }

     
    }
}