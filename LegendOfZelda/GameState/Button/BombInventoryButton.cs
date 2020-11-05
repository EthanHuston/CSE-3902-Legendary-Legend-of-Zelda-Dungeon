using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.GameState.Button
{
    class BombInventoryButton : ISpawnable
    {
        private readonly ITextureAtlasSprite sprite;
        private readonly SpriteBatch spriteBatch;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public BombInventoryButton(SpriteBatch spriteBatch, Point spawnPosition)
        {
            this.spriteBatch = spriteBatch;
            Position = spawnPosition;
            sprite = GameStateSpriteFactory.Instance.CreateHudItemsSprite();
        }


        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, Position, GameStateConstants.BombTexureAtlasLocation);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
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
