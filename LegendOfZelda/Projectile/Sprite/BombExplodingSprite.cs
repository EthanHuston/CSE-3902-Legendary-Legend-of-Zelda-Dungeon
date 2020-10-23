using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    class BombExplodingSprite : IProjectileSprite
    {
        private readonly Texture2D sprite;
        private bool animationIsFinished;
        private int delayBeforeExplosionCounter;
        private int bufferFrame;
        private int currentFrame;
        private Rectangle destinationRectangle;
        private const int totalFrames = 4;
        private const int numRows = 1;
        private const int numColumns = 4;
        private const int delayBeforeExplosion = 60;

        public BombExplodingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            delayBeforeExplosionCounter = 0;
            bufferFrame = 0;
            currentFrame = 0;
            destinationRectangle = Rectangle.Empty;
        }

        public void Update()
        {
            if (FinishedAnimation()) return;
            if (++delayBeforeExplosionCounter > delayBeforeExplosion && ++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            animationIsFinished = currentFrame >= totalFrames - 1;
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            if (FinishedAnimation()) return;

            int width = sprite.Width / numColumns;
            int height = sprite.Height / numRows;
            int currentRow = 0;
            int currentColumn = currentFrame % totalFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentColumn, height * currentRow, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(width * Constants.GameScaler), (int)(height * Constants.GameScaler));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public bool FinishedAnimation()
        {
            return animationIsFinished;
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }
    }
}
