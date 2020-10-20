using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class ShutDoor : IBlock
    {
        private ITextureAtlasSprite doorSprite;
        private SpriteBatch sB;
        private Point position;
        private bool safeToDespawn;
        private const int textureAtlasColumn = 1;
        private const int textureAtlasRow = 3;

        public ShutDoor(SpriteBatch spriteBatch, Point position)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            this.position = new Point(position.X, position.Y);
            safeToDespawn = false;
        }

        public void Draw()
        {
            doorSprite.Draw(sB, position, new Point(textureAtlasColumn, textureAtlasRow));
        }

        public void Update()
        {
            doorSprite.Update();
        }

        public void Move(Vector2 distance)
        {
            position = new Point((int)(position.X + distance.X), (int)(position.Y + distance.Y));
        }

        public void SetPosition(Point position)
        {
            this.position = new Point(position.X, position.Y);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public Point GetPosition()
        {
            return new Point(position.X, position.Y);
        }

        public Rectangle GetRectangle()
        {
            return doorSprite.GetPositionRectangle();
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }
    }
}
