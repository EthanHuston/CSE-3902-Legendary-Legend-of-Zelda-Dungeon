using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class ShutDoor : IBlock
    {
        private ITextureAtlasSprite doorSprite;
        private SpriteBatch sB;
        private bool safeToDespawn;
        private const int textureAtlasColumn = 1;
        private const int textureAtlasRow = 3;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public ShutDoor(SpriteBatch spriteBatch, Point position)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            Position = position;
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

        public bool SafeToDespawn()
        {
            return safeToDespawn;
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
