﻿using MarioClone.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioClone.Factories
{
    public class MovingEnemySpriteFactory : EnemySpriteFactory
    {
        static MovingEnemySpriteFactory _factory;
        public static MovingEnemySpriteFactory Instance
        {
            get
            {
                if(_factory == null)
                {
                    _factory = new MovingEnemySpriteFactory();
                }
                return _factory;
            }
        }

        public override ISprite Create(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Goomba:
                    return new AnimatedSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/Goomba"),
                        new Rectangle(0, 0, 42, 32), 1, 3, 0, 1, 4);
                case EnemyType.GreenKoopa:
                    return new AnimatedSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/GreenKoopa"),
                        new Rectangle(0, 0, 32, 32), 1, 4, 0, 1, 4);
                case EnemyType.RedKoopa:
                    return new AnimatedSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/RedKoopa"),
                        new Rectangle(0, 0, 32, 32), 1, 4, 0, 1, 4);
                default:
                    return new AnimatedSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/Goomba"),
                        new Rectangle(0, 0, 42, 32), 1, 3, 0, 1, 4);
            }
        }
    }
}