using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class HeartContainer : IItem
    {
        private IItemSprite heartContainerSprite;
        private SpriteBatch sb;
        private Point position;
        private bool safeToDespawn;

        public HeartContainer(SpriteBatch spriteBatch, Point spawnPosition)
        {
            heartContainerSprite = (HeartContainerSprite)SpriteFactory.Instance.CreateHeartContainerSprite();
            sb = spriteBatch;
            position = spawnPosition;
            safeToDespawn = false;
        }

        public void Draw()
        {
            heartContainerSprite.Draw(sb, position);
        }

        public Point GetPosition()
        {
            return position;
        }

        public Rectangle GetRectangle()
        {
            return heartContainerSprite.GetPositionRectangle();
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
            this.position = position;
        }

        public void Update()
        {
            safeToDespawn = !safeToDespawn && false;
        }
    }
}
