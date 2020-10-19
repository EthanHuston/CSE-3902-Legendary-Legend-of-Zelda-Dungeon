using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment
{
    class BrickTile : IBlock
    {
        private ISprite brickTileSprite;
        private SpriteBatch sB;
        private Point position;
        private bool safeToDespawn;

        public BrickTile(SpriteBatch spriteBatch, Point spawnPosition)
        {
            brickTileSprite = EnvironmentSpriteFactory.Instance.CreateBrickTileSprite();
            sB = spriteBatch;
            position = spawnPosition;
            safeToDespawn = false;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            brickTileSprite.Draw(sB, position);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return brickTileSprite.GetPositionRectangle();
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
        }
    }
}
