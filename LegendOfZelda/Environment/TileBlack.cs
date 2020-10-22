﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class TileBlack : IBlock
    {
        private ISprite sprite;
        private SpriteBatch sb;
        private bool safeToDespawn;
        bool canWalk;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public TileBlack(SpriteBatch spriteBatch, Point position)
        {
            sprite = EnvironmentSpriteFactory.Instance.CreateTileBlackSprite();
            sb = spriteBatch;
            Position = position;
            canWalk = false;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            sprite.Draw(sb, position);
        }

        public Rectangle GetRectangle()
        {
            return sprite.GetPositionRectangle();
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            sprite.Update();
        }
    }
}
