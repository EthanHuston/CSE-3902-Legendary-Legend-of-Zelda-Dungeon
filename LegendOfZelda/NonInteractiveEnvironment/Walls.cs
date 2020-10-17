using LegendOfZelda.Interface;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.NonInteractiveEnvironment
{
    class Walls : IBlock
    {
        private ISprite roomBorderSprite;
        private SpriteBatch sB;
        private Point position;
        private bool safeToDespawn;

        public Walls(SpriteBatch spriteBatch, Point spawnPosition)
        {
            roomBorderSprite = SpriteFactory.Instance.CreateRoomBorderSprite();
            sB = spriteBatch;
            position.X = spawnPosition.X;
            position.Y = spawnPosition.Y;
            safeToDespawn = false;
        }

        public void Draw()
        {
            roomBorderSprite.Draw(sB, new Point(ConstantsSprint2.InteractiveEnvironmentSpawnX, ConstantsSprint2.InteractiveEnvironmentSpawnY));
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return roomBorderSprite.GetPositionRectangle();
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
            this.position = new Point(position.X, position.Y);
        }

        public void Update()
        {
            safeToDespawn = !safeToDespawn && false; // some condition here to despawn if it has not already been marked for despawn
        }
    }
}
