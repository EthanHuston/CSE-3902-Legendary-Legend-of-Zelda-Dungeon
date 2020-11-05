using LegendOfZelda.Interface;
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
            wallSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow));
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0, 0, wallSprite.GetPositionRectangle().Width, wallSprite.GetPositionRectangle().Height);
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
