using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.InteractiveEnvironment
{
    class Square : IDynamic
    {
        private ISprite blockSprite;
        private SpriteBatch spriteBatch;
        private Point position;
        private bool safeToDespawn;

        public Square(SpriteBatch spriteBatch, Point spawnPosition)
        {
            blockSprite = SpriteFactory.Instance.CreateBlockSprite();
            this.spriteBatch = spriteBatch;
            position.X = spawnPosition.X;
            position.Y = spawnPosition.Y;
            safeToDespawn = false;
        }

        public void Draw()
        {
            spriteBatch.Begin();
            blockSprite.Draw(spriteBatch, position);
            spriteBatch.End();
        }

        public void Update()
        {
            safeToDespawn = false; // put some condition here that evaluates to true when we can despawn block
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return blockSprite.GetPositionRectangle();
        }

        public Vector2 GetVelocity()
        {
            return Vector2.Zero;
        }

        public void Move(Vector2 distance)
        {
            position.X += (int) distance.X;
            position.Y += (int) distance.Y;
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void SetPosition(Point position)
        {
            this.position.X = position.X;
            this.position.Y = position.Y;
        }
    }
}
