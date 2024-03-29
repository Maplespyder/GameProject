﻿using MarioClone.EventCenter;
using MarioClone.Factories;
using MarioClone.GameObjects;
using MarioClone.Sounds;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static MarioClone.States.MarioPowerupState;

namespace MarioClone.States.BlockStates
{
    public class BreakableBrickBreak : BlockState
    {
        new BreakableBrickObject Context;

        public BreakableBrickBreak(BreakableBrickObject context) : base(context)
        {
            //don't remove, it's for casting
            Context = context;

            Context.BoundingBox = null;
            Context.Visible = false;

            EventManager.Instance.TriggerBrickBumpedEvent(Context, Context.ContainedPowerup, true);

            List<Vector2> velocityList = new List<Vector2>
            {
                new Vector2(1, 0),
                new Vector2(-1, 0),
                new Vector2(-2, 0),
                new Vector2(2, 0)
            };

            var oldFactory = BlockFactory.SpriteFactory;
            if (Context.LevelArea == 0)
            {
                BlockFactory.SpriteFactory = NormalThemedBlockSpriteFactory.Instance;
            }
            else
            {
                BlockFactory.SpriteFactory = SubThemedBlockSpriteFactory.Instance;
            }

            for (int i = 0; i < 4; i++)
            {
                var piece = (BrickPieceObject)BlockFactory.Instance.Create(BlockType.BrickPiece, context.Position);
                piece.LevelArea = Context.LevelArea;
                Context.PieceList.Add(piece);
                piece.ChangeVelocity(velocityList[i]);
            }

            BlockFactory.SpriteFactory = oldFactory;
        }

        public override bool Action(float percent, GameTime gameTime)
        {
            List<BrickPieceObject> invisiblePiece = new List<BrickPieceObject>();
            bool disposeMe = false;
            foreach (BrickPieceObject piece in Context.PieceList)
            {
                if (piece.Update(gameTime, percent))
                {
                    invisiblePiece.Add(piece);
                }
            }

            //Remove pieces from PieceList
            foreach (BrickPieceObject piece in invisiblePiece)
            {
                if (Context.PieceList.Contains(piece))
                {
                    Context.PieceList.Remove(piece);
                }
            }

            //If all pieces are gone
            if (Context.PieceList.Count == 0)
            {
                disposeMe = true;
                Context.BoundingBox = new Collision.HitBox(0, 0, 0, 0, Color.Blue);
                Context.BoundingBox.UpdateHitBox(Context.Position, Context.Sprite);
            }

            return disposeMe;
        }
    }
}
