using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    class Walls : IBlock
    {
        private ITextureAtlasSprite wallSprite;
        private SpriteBatch sB;
        private bool safeToDespawn;
        private int textureMapRow;
        private const int textureMapColumn = 1;

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
            if ((position.X != Constants.MinXPos) && (position.Y == Constants.MinYPos))
            {
                textureMapRow = 1;
            }
            else if ((position.X == Constants.MinXPos) && (position.Y != Constants.MinYPos))
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
            wallSprite.Draw(sB, position, new Point(textureMapColumn, textureMapRow));
        }

        public Rectangle GetRectangle()
        {
            return wallSprite.GetPositionRectangle();
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
