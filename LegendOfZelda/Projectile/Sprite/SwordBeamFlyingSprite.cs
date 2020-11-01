using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    internal class SwordBeamFlyingSprite : IProjectileSprite
    {
        private readonly Texture2D sprite;
        private int bufferFrame;
        private int currentFrame;
        private readonly int totalFrames;
        private readonly int frameWidth;
        private readonly int frameHeight;
        private const int numRows = 1;
        private const int numColumns = 4;
        private const int frameDelay = 10;

        public SwordBeamFlyingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            bufferFrame = 0;
            currentFrame = 0;
            totalFrames = numColumns * numRows;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;
        }

        public void Update()
        {
            if (++bufferFrame == frameDelay)
            {
                currentFrame = currentFrame == totalFrames - 1 ? 0 : currentFrame + 1;
                bufferFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            int currentRow = 0;
            int currentColumn = currentFrame;

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public bool FinishedAnimation()
        {
            return false; // not used, BoomerangFlying class keeps track of this
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, frameWidth, frameHeight);
        }
    }
}
