﻿using MarioClone.Collision;
using MarioClone.Sprites;
using MarioClone.States.BlockStates;
using Microsoft.Xna.Framework;

namespace MarioClone.GameObjects
{
    public class QuestionBlockObject : AbstractBlock
	{

		public QuestionBlockObject(ISprite sprite,  Vector2 position) : base(sprite,  position)
        {
            State = new QuestionBlockStatic(this);
        }

		public override bool Update(GameTime gameTime, float percent)
        {
            base.Update(gameTime, percent);
			return State.Action(percent, gameTime);
        }

        public override bool CollisionResponse(AbstractGameObject gameObject, Side side, GameTime gameTime)
        {
            if (gameObject is Mario && side == Side.Bottom)
            {
                State.Bump((Mario)gameObject); 
                return true;
            }
            return false;
        }
    }
}
