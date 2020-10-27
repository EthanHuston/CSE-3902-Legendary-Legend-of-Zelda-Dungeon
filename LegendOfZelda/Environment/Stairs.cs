using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class Stairs : IBlock
    {
        private ISprite stairSprite;
        private SpriteBatch sB;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Stairs(SpriteBatch spriteBatch, Point position)
        {
            stairSprite = EnvironmentSpriteFactory.Instance.CreateStairSprite();
            sB = spriteBatch;
            Position = new Point(position.X, position.Y);
            safeToDespawn = false;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            stairSprite.Draw(sB, Position);
        }

        public Rectangle GetRectangle()
        {
            return stairSprite.GetPositionRectangle();
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            stairSprite.Update();
        }
    }
}
