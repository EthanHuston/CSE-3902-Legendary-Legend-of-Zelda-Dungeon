using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class OpenDoor : IBlock
    {
        private readonly ITextureAtlasSprite doorSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;
        private int textureMapRow;
        private const int textureMapColumn = 0;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public OpenDoor(SpriteBatch spriteBatch, Point spawnPosition)
        {
            doorSprite = EnvironmentSpriteFactory.Instance.CreateDoorSprite();
            sB = spriteBatch;
            safeToDespawn = false;
            Position = spawnPosition;
        }

        public void Draw()
        {
            if ((position.X == RoomConstants.TopDoorX) && (position.Y == RoomConstants.TopDoorY))
            {
                textureMapRow = 0;
            }
            else if ((position.X == RoomConstants.LeftDoorX) && (position.Y == RoomConstants.LeftDoorY))
            {
                textureMapRow = 1;
            }
            else if ((position.X == RoomConstants.RightDoorX) && (position.Y == RoomConstants.RightDoorY))
            {
                textureMapRow = 2;
            }
            else if ((position.X == RoomConstants.BottomDoorX) && (position.Y == RoomConstants.BottomDoorY))
            {
                textureMapRow = 3;
            }
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow));
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, doorSprite.GetPositionRectangle().Width, doorSprite.GetPositionRectangle().Height);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            doorSprite.Update();
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }
    }
}
