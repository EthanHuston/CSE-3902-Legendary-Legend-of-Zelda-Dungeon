﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment
{
    class BombedOpening : IBlock
    {
        private ITextureAtlasSprite doorSprite;
        private SpriteBatch sB;
        private bool safeToDespawn;
        private int textureMapRow;
        private const int textureMapColumn = 4;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public BombedOpening(SpriteBatch spriteBatch, Point spawnPosition)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
        }

        public void Draw()
        {
            if ((position.X != Constants.MinXPos) && (position.Y == Constants.MinYPos))
            {
                textureMapRow = 1;
            }
            else if ((position.X == Constants.MinXPos) && (position.Y != Constants.MinYPos))
            {
                textureMapRow = 2;
            }
            else if ((position.X == Constants.MaxXPos) && (position.Y != Constants.MinYPos))
            {
                textureMapRow = 3;
            }
            else if ((position.X != Constants.MinXPos) && (position.Y == Constants.MaxYPos))
            {
                textureMapRow = 4;
            }
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow));
        }

        public Rectangle GetRectangle()
        {
            return doorSprite.GetPositionRectangle();
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            doorSprite.Update();
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Move(int distance, Vector2 velocity)
        {
            throw new System.NotImplementedException();
        }
    }
}