using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.GameState.Rooms
{
    class ExitButton : ISpawnable
    {
        private readonly ISprite sprite;
        private readonly SpriteBatch spriteBatch;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public ExitButton(SpriteBatch spriteBatch, Point spawnPosition)
        {
            this.spriteBatch = spriteBatch;
            sprite = GameStateSpriteFactory.Instance.CreateExitButtonSprite();
            Position = spawnPosition;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            sprite.Draw(spriteBatch, Position);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0, 0, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
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
