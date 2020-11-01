using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class ShutDoor : IBlock
    {
        private readonly ITextureAtlasSprite doorSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;
        private const int textureMapColumn = 2;
        private int textureMapRow;

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
            if ((position.X == RoomConstants.topDoorX) && (position.Y == RoomConstants.topDoorY))
            {
                textureMapRow = 0;
            }
            else if ((position.X == RoomConstants.leftDoorX) && (position.Y == RoomConstants.leftDoorY))
            {
                textureMapRow = 1;
            }
            else if ((position.X == RoomConstants.rightDoorX) && (position.Y == RoomConstants.rightDoorY))
            {
                textureMapRow = 2;
            }
            else if ((position.X == RoomConstants.bottomDoorX) && (position.Y == RoomConstants.bottomDoorY))
            {
                textureMapRow = 3;
            }
            doorSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow));
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
