using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment
{
    class BrickTile : IBlock
    {
        private ISprite brickTileSprite;
        private SpriteBatch sB;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

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
            brickTileSprite.Draw(sB, Position);
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return brickTileSprite.GetPositionRectangle();
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
