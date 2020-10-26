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

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, doorSprite.GetPositionRectangle().Width, doorSprite.GetPositionRectangle().Height);
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

        public void Update()
        {
            doorSprite.Update();
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Move(int distance, Vector2 velocity)
        {
            throw new System.NotImplementedException();
        }
    }
}
