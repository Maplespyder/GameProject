﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MarioClone.GameObjects;

namespace MarioClone.States.EnemyStates.Powerup
{
    public class BowserInvincibility : BowserPowerupState
    {
        int colorChangeDelay;
        public const int MaxInvincibleDuration = 3000;

        public int InvincibleTime { get; private set; }

        public BowserInvincibility(BowserObject context) : base(context)
        {
            Powerup = BowserPowerup.Invincible;
			Context.SpriteTint = new Color(Color.White, 100);

		}

        public override void BecomeDead()
		{
		    Context.PowerupStateBowser = new BowserDead(Context);
		}

        public override void BecomeInvincible() { }
		public override void BecomeAlive()
		{
			Context.PowerupStateBowser = new BowserAlive(Context);
		}


		public override bool Update(GameTime gameTime, float percent)
        {
            CycleTransparency();
            InvincibleTime += gameTime.ElapsedGameTime.Milliseconds;
            if (InvincibleTime >= MaxInvincibleDuration)
            {
				Context.SpriteTint = Color.White;
				BecomeAlive();

            }
            return false;
        }

        private void CycleTransparency()
        {
            colorChangeDelay++;
            if (colorChangeDelay >= 15)
            {
                if (Context.SpriteTint.A == 100)
                {
                    Context.SpriteTint = Color.White;
                }
                else
                {
                    Context.SpriteTint = new Color(Color.White, 100);
                }
                colorChangeDelay = 0;
            }
        }

    }
}

