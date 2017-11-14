﻿using MarioClone.GameObjects;
using Microsoft.Xna.Framework;

namespace MarioClone.Factories
{
    public enum ProjectileType
	{
		FireBall
	}

	public class ProjectileFactory
	{

		public static AbstractGameObject Create(ProjectileType type, Vector2 position)
		{
			switch (type)
			{
				case ProjectileType.FireBall:
					return new FireBall(ProjectileSpriteFactory.Create(type), position);
				default:
					return new FireBall(ProjectileSpriteFactory.Create(type), position);
			}
		}
	}
}
