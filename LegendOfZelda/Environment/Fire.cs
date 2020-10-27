using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment
{
    class Fire : IBlock
    {
        private ISprite fireSprite;
        private SpriteBatch sB;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Fire(SpriteBatch spriteBatch, Point spawnPosition)
        {
            fireSprite = EnvironmentSpriteFactory.Instance.CreateFireSprite();
            sB = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            fireSprite.Draw(sB, Position);
        }

        public Rectangle GetRectangle()
        {
            return fireSprite.GetPositionRectangle();
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            fireSprite.Update();
        }
    }
}
