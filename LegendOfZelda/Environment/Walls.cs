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
        private int textureMapRow;
        private const int textureMapColumn = 0;
        private readonly Constants.Direction side;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }
        private bool safeToDespawn;
        public bool SafeToDespawn { get =>safeToDespawn; set => safeToDespawn = safeToDespawn || value; }

        public Walls(SpriteBatch spriteBatch, Point spawnPosition)
        {
            wallSprite = EnvironmentSpriteFactory.Instance.CreateWallSprite();
            sB = spriteBatch;
            Position = spawnPosition;
            SafeToDespawn = false;
            side = RoomUtilities.GetDoorSide(spawnPosition);
        }

        public void Despawn()
        {
            SafeToDespawn = true;
        }

        public void Draw()
        {
            textureMapRow = RoomUtilities.GetDirectionalTextureAtlasRow(side);
            wallSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow), Constants.DrawLayer.Wall);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, wallSprite.GetPositionRectangle().Width, wallSprite.GetPositionRectangle().Height);
        }

        public void Update()
        {
            wallSprite.Update();
        }
    }
}
