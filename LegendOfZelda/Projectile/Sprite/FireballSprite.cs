using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    internal class FireballSprite : IProjectileSprite
    {
        private readonly Texture2D sprite;
        private const int numRows = 1;
        private const int numColumns = 4;
        private const int frameDelay = 3;
        private int currentFrame;
        private int bufferFrame;
        private readonly int totalFrames;
        private readonly int width;
        private readonly int height;

        public FireballSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = numRows * numColumns;
            width = sprite.Width / numColumns;
            height = sprite.Height / numRows;
        }

        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == frameDelay)
            {
                bufferFrame = 0;
                currentFrame++;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            int row = currentFrame % numRows;
            int column = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * width), (int)(Constants.GameScaler * height));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, width, height);
        }

        public bool FinishedAnimation()
        {
            return false; // animation does not finish
        }
    }
}
