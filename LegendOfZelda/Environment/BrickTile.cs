﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment
{
    internal class BrickTile : IBlock
    {
        private readonly ISprite brickTileSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public BrickTile(SpriteBatch spriteBatch, Point spawnPosition)
        {
            brickTileSprite = EnvironmentSpriteFactory.Instance.CreateBrickTileSprite();
            sB = spriteBatch;
            position = spawnPosition;
            SafeToDespawn = false;
        }

        
        public void Draw()
        {
            brickTileSprite.Draw(sB, Position, Constants.DrawLayer.FloorTile);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, brickTileSprite.GetPositionRectangle().Width, brickTileSprite.GetPositionRectangle().Height);
        }
        
        public void SetPosition(Point position)
        {
            this.position = new Point(position.X, position.Y);
        }

        public void Update()
        {
        }
    }
}
