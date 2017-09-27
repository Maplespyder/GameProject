﻿using MarioClone.Factories;
using MarioClone.Sprites;
using MarioClone.States.BlockStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace MarioClone.GameObjects
{
    public class BreakableBrickObject : AbstractBlock
	{
		private List<IGameObject> pieceList = new List<IGameObject>();
		List<BrickPieceObject> invisiblePiece = new List<BrickPieceObject>();

        public BreakableBrickObject(ISprite sprite, Vector2 position, int drawOrder) : base( sprite, position, drawOrder)
        {
            State = new BreakableBrickStatic(this);
        }

        public void Break()
        {
            Visible = false;
            List<Vector2> velocityList = new List<Vector2>
            {
                new Vector2(1, 0),
                new Vector2(-1, 0),
                new Vector2(-2, 0),
                new Vector2(2, 0)
            };

            for (int i = 0; i < 4; i++)
			{
				var piece = (BrickPieceObject)BlockFactory.Instance.Create(BlockType.BrickPiece, Position); 
				pieceList.Add(piece);
				piece.ChangeVelocity(velocityList[i]);
			}
        }

		public bool Pieces(GameTime gameTime)
		{
            bool disposeMe = false;
			foreach(BrickPieceObject piece in pieceList)
			{
				if (piece.Update(gameTime))
				{
					invisiblePiece.Add(piece);
				}
			}

			//Remove pieces from PieceList
			foreach(BrickPieceObject piece in invisiblePiece)
			{
				if (pieceList.Contains(piece))
				{
					pieceList.Remove(piece);
				}
			}

			//If all pieces are gone
			if(pieceList.Count == 0)
			{
                disposeMe = true;
			}

            return disposeMe;
		}

		public override bool Update(GameTime gameTime)
        {
            return State.Action() && Pieces(gameTime);
        }

		

		public override void Draw(SpriteBatch spriteBatch,  GameTime gameTime)
		{
            if (Visible)
            {
                Sprite.Draw(spriteBatch, Position, DrawOrder, gameTime, Facing.Left);
            }
			foreach (BrickPieceObject piece in pieceList)
			{
				piece.Draw(spriteBatch,  gameTime);
			}
		}
        public override void Bump()
        {
            State.Bump();
        }
    }
}
