﻿using MarioClone.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MarioClone.States;
using static MarioClone.States.MarioActionState;

namespace MarioClone.Factories
{
    public class SuperMarioSpriteFactory : MarioSpriteFactory
    {
        static SuperMarioSpriteFactory _factory;

        private SuperMarioSpriteFactory() : base() { }

        public static MarioSpriteFactory Instance
        {
            get
            {
                if (_factory == null)
                {
                    _factory = new SuperMarioSpriteFactory();
                }
                return _factory;
            }
        }

        public override ISprite Create(MarioAction action)
        {
            switch (action)
            {
                case MarioAction.Idle:
                    return new StaticSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/BigMario"), new Rectangle(0, 0, 96, 128));
                case MarioAction.Walk:
                    return new AnimatedSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/BigMario"), new Rectangle(0, 0, 96, 128),
                        1, 8, 0, 1, 4);
                /*case MarioAction.Run:
                    return new AnimatedSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/BigMario"), new Rectangle(0, 0, 96, 128),
                        1, 8, 5, 7, 6);*/
                case MarioAction.Jump:
                    return new StaticSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/BigMario"), new Rectangle(288, 0, 96, 128));
                case MarioAction.Crouch:
                    return new StaticSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/BigMario"), new Rectangle(384, 0, 96, 128));
                /*case MarioAction.Fall:
                    return new StaticSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/BigMario"), new Rectangle(384, 0, 96, 128));*/
                default:
                    //default will be idling
                    return new StaticSprite(MarioCloneGame.GameContent.Load<Texture2D>("Sprites/BigMario"), new Rectangle(0, 0, 96, 128));

            }

        }
    }
}
