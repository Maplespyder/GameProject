﻿using System;
using MarioClone.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MarioClone.Factories;
using MarioClone.States;
using MarioClone.Collision;
using static MarioClone.Collision.GameGrid;
using MarioClone.States.EnemyStates.Powerup;

namespace MarioClone.GameObjects.Enemies
{
	public class PiranhaObject : AbstractEnemy
	{
		public PiranhaObject(ISprite sprite, Vector2 position) : base(sprite, position)
		{
			BoundingBox.UpdateOffSets(-8, -8, -8, -8);
			BoundingBox.UpdateHitBox(Position, Sprite);
			DrawOrder = .52f;
			PowerupState = new PiranhaHide(this);
			Velocity = new Vector2(0, 0);
            PointValue = 500;
        }

        public override void FixClipping(Vector2 correction, AbstractGameObject obj1, AbstractGameObject obj2) { }

        public override bool CollisionResponse(AbstractGameObject gameObject, Side side, GameTime gameTime)
		{
			//None Yet
			return false;
		}
        
		public override bool Update(GameTime gameTime, float percent)
		{
			bool retVal = PowerupState.Update(gameTime, percent);
            Removed = base.Update(gameTime, percent) || retVal;
			return Removed;
		}
	}
}
