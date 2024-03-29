﻿using MarioClone.GameObjects;
using Microsoft.Xna.Framework;

namespace MarioClone.Factories
{
    public static class MarioFactory
    {
        public static Mario Create(Vector2 position)
        {
            return new Mario(position);
        }
    }
}
