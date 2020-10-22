using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class Stairs : IBlock
    {
        private ISprite stairSprite;
        private SpriteBatch sB;
        private Point position;
        private bool safeToDespawn;

        public Stairs(SpriteBatch spriteBatch, Point position)
        {
            stairSprite = EnvironmentSpriteFactory.Instance.CreateStairSprite();
            sB = spriteBatch;
            this.position = new Point(position.X, position.Y);
            safeToDespawn = false;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            stairSprite.Draw(sB, position);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return stairSprite.GetPositionRectangle();
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
            stairSprite.Update();
        }
    }
}
