using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.Button
{
    class ResumeButton : IButton
    {
        private readonly ISprite sprite;
        private readonly SpriteBatch spriteBatch;
        private bool safeToDespawn;
        private bool isActive;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public ResumeButton(SpriteBatch spriteBatch, Point spawnPosition)
        {
            this.spriteBatch = spriteBatch;
            sprite = GameStateSpriteFactory.Instance.CreateResumeButtonSprite();
            Position = spawnPosition;
            safeToDespawn = false;
            isActive = true;
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
            return !isActive ?
                Rectangle.Empty :
                new Rectangle(Position.X, Position.Y, sprite.GetPositionRectangle().Width, sprite.GetPositionRectangle().Height);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            sprite.Update();
        }

        public void MakeActive()
        {
            isActive = true;
        }

        public void MakeInactive()
        {
            isActive = false;
        }
    }
}
