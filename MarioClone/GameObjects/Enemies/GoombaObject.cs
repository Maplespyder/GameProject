﻿using System;
using MarioClone.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MarioClone.GameObjects
{
    public class GoombaObject : IGameObject, IMoveable
    {

        public Vector2 Position { get; protected set; }

        public Vector2 Velocity { get; }

        public int DrawOrder { get; }

        public bool Visible { get; protected set; }

        public ISprite Sprite { get; protected set; }

        public GoombaObject(ISprite sprite,Vector2 velocity, Vector2 position)
        {
            //need to add in states
            Sprite = sprite;
            Velocity = velocity;
            Position = position;
            Visible = true;
        }

        public void Draw(SpriteBatch spriteBatch, float layer, GameTime gameTime)
        {
            if (Visible)
            {
                Sprite.Draw(spriteBatch, Position, layer, gameTime);
            }
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public bool Update(GameTime gameTime)
        {
            return false;
        }
    }
}
