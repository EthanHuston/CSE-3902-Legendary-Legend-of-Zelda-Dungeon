using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class OpenDoor : IBlock
    {
        private ITextureAtlasSprite doorSprite;
        private SpriteBatch sB;
        private bool safeToDespawn;
        private Point position;
        private const int textureMapRow = 1;
        private const int textureMapColumn = 1;

        public OpenDoor(SpriteBatch spriteBatch, Point spawnPosition)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            safeToDespawn = false;
            position = spawnPosition;
        }

        public void Draw()
        {
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow));
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return doorSprite.GetPositionRectangle();
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
            safeToDespawn = !safeToDespawn && false; // condition goes here to despawn if we want
        }
    }
}
