using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.NonInteractiveEnvironment
{
    class Fire : IBlock
    {
        private ISprite fireSprite;
        private SpriteBatch sB;
        private Point position;
        private bool safeToDespawn;

        public Fire(SpriteBatch spriteBatch, Point spawnPosition)
        {
            fireSprite = SpriteFactory.Instance.CreateFireSprite();
            sB = spriteBatch;
            position = spawnPosition;
            safeToDespawn = false;
        }

        public void Draw()
        {
            fireSprite.Draw(sB, position);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return fireSprite.GetPositionRectangle();
        }

        public void Move(Vector2 distance)
        {
            position.X += (int)distance.X;
            position.Y += (int)distance.Y;
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
            fireSprite.Update();
            safeToDespawn = !safeToDespawn && false; // some condition here to determine when to despawn
        }
    }
}
