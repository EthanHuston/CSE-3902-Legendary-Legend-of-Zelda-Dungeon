using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class Statues : IBlock
    {
        private ISprite statueSprite;
        private SpriteBatch sB;
        private Point position;
        private bool safeToDespawn;

        public Statues(SpriteBatch spriteBatch, Point position)
        {
            statueSprite = EnvironmentSpriteFactory.Instance.CreateStatueSprite();
            sB = spriteBatch;
            this.position = new Point(position.X, position.Y);
            safeToDespawn = true;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            statueSprite.Draw(sB, position);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return statueSprite.GetPositionRectangle();
        }

        public void Move(Vector2 distance)
        {
            position = new Point((int)(position.X + distance.X), (int)(position.Y + distance.Y));
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void SetPosition(Point position)
        {
            this.position = new Point(position.X, position.Y);
        }

        public void Update()
        {
            statueSprite.Update();
        }
    }
}
