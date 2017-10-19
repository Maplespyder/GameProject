﻿using MarioClone.Collision;
using MarioClone.Sprites;
using MarioClone.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarioClone.GameObjects
{
	public class FireFlowerObject : AbstractGameObject
	{
        public FireFlowerObject(ISprite sprite, Vector2 position) : base(sprite, position, Color.Green)
        {
            BoundingBox.UpdateOffSets(4, 4, 0, 0);
            BoundingBox.UpdateHitBox(Position, Sprite);
        }
    }
}
