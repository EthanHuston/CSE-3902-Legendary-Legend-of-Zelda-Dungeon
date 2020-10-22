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
        private int textureMapRow;
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
            if((position.X != Constants.MinXPos) && (position.Y == Constants.MinYPos))
            {
                textureMapRow = 1;
            }
            else if((position.X == Constants.MinXPos) && (position.Y != Constants.MinYPos))
            {
                textureMapRow = 2;
            }
            else if ((position.X == Constants.MaxXPos) && (position.Y != Constants.MinYPos))
            {
                textureMapRow = 3;
            }
            else if ((position.X != Constants.MinXPos) && (position.Y == Constants.MaxYPos))
            {
                textureMapRow = 4;
            }
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
