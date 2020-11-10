using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class Walls : IBlock
    {
        private readonly ITextureAtlasSprite wallSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;
        private int textureMapRow;
        private const int textureMapColumn = 0;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public Walls(SpriteBatch spriteBatch, Point spawnPosition)
        {
            wallSprite = EnvironmentSpriteFactory.Instance.CreateWallSprite();
            sB = spriteBatch;
            Position = spawnPosition;
            safeToDespawn = false;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            textureMapRow = RoomUtilities.GetDirectionalTextureAtlasRow(Position);
            wallSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow), Constants.DrawLayer.Wall);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, wallSprite.GetPositionRectangle().Width, wallSprite.GetPositionRectangle().Height);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            wallSprite.Update();
        }
    }
}
