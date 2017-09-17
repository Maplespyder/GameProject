﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioClone.GameObjects
{
    public interface IMoveable
    {
        void Move();
    
        Vector2 Velocity { get; set; }

    }
}
