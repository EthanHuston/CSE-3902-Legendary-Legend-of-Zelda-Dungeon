using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class LockedDoor : IBlock
    {
        private ITextureAtlasSprite doorSprite;
        private SpriteBatch sB;
        private bool safeToDespawn;
        private const int textureMapRow = 2;
        private const int textureMapColumn = 1;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public LockedDoor(SpriteBatch spriteBatch, Point spawnPosition)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
        }

        public void Draw()
        {
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow));
        }

        public void Update()
        {
            safeToDespawn = !safeToDespawn && false; // put condition here for when door can be despawned
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
