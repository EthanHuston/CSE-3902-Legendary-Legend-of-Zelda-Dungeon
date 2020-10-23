using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    class BoomerangFlyingSprite : IProjectileSprite
    {
        private readonly Texture2D sprite;
        private int bufferFrame;
        private int currentFrame;
        private int frameWidth;
        private int frameHeight;
        private const int totalFrames = 8;
        private const int numRows = 1;
        private const int numColumns = 8;

        public BoomerangFlyingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            bufferFrame = 0;
            currentFrame = 0;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;
        }

        public void Update()
        {
            if (++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            int currentRow = 0;
            int currentColumn = currentFrame % totalFrames;

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged)
        {
            Draw(spriteBatch, position);
        }

        public bool FinishedAnimation()
        {
            return false; // not used, BoomerangFlying class keeps track of this
        }

        public Rectangle GetPositionRectangle()
        {
            return sprite.Bounds;
        }
    }
}
