﻿using MarioClone.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioClone.Factories
{
    public static class MovingEnemySpriteFactory
    {
        public static ISprite Create(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Goomba:
                    return new AnimatedSprite(MarioCloneGame.GameContent.Load<Texture2D>("CustomSprites/GreenEnemy"),
                        new Rectangle(0, 0, 210, 82),1,4,0,3,6);
                case EnemyType.GreenKoopa:
                    return new AnimatedSprite(MarioCloneGame.GameContent.Load<Texture2D>("CustomSprites/PinkEnemy"),
                        new Rectangle(0, 0, 110, 111), 1,4,0,3,4);
                case EnemyType.Piranha:
					return new AnimatedSprite(MarioCloneGame.GameContent.Load<Texture2D>("CustomSprites/CustomPlant"),
						new Rectangle(0, 0, 122, 105), 1, 2, 0, 1, 4);
                case EnemyType.BowserWalk:
                    return new AnimatedSprite(MarioCloneGame.GameContent.Load<Texture2D>("CustomSprites/Boss"),
                        new Rectangle(0, 0, 872, 254), 4, 1, 0, 3, 4);
                case EnemyType.BowserFire:
                    return new StaticSprite(MarioCloneGame.GameContent.Load<Texture2D>("CustomSprites/BossFire"),
						new Rectangle(0, 0, 890, 246));
				case EnemyType.BowserIdle:
					return new StaticSprite(MarioCloneGame.GameContent.Load<Texture2D>("CustomSprites/Boss"),
						new Rectangle(0, 762, 872, 254));
				default:
                    return new AnimatedSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/Goomba"),
                        new Rectangle(0, 0, 64, 64), 1, 3, 0, 1, 4);
            }
        }
    }
}
