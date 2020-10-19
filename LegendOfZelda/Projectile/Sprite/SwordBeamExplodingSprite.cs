using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Projectile.Sprite
{
    class SwordBeamExplodingSprite : IItemSprite
    {
        private Texture2D upLeftSprite, upRightSprite, downLeftSprite, downRightSprite;
        private bool animationIsFinished;
        private int xOffset;
        private int yOffset;
        private int bufferFrame;
        private int currentFrame;
        private int totalFrames;
        private const int frameDelay = 2;
        private const int numRows = 1;
        private const int numColumns = 4;
        private const int explosionDistanceInterval = 1;
        private const int explosionRange = 50;

        public SwordBeamExplodingSprite(Texture2D upLeftSprite, Texture2D upRightSprite, Texture2D downLeftSprite, Texture2D downRightSprite)
        {
            this.upLeftSprite = upLeftSprite;
            this.upRightSprite = upRightSprite;
            this.downLeftSprite = downLeftSprite;
            this.downRightSprite = downRightSprite;
            animationIsFinished = false;
            bufferFrame = 0;
            currentFrame = 0;
            xOffset = 0;
            yOffset = 0;
            totalFrames = numRows * numColumns;
        }

        public void Update()
        {
            if (FinishedAnimation()) return;
            if (++bufferFrame == frameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            xOffset += explosionDistanceInterval;
            yOffset += explosionDistanceInterval;

            animationIsFinished = Math.Sqrt(Math.Pow(xOffset, 2) + Math.Pow(yOffset, 2)) > explosionRange;
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            int width, height;
            int currentRow = 0;
            int currentColumn = currentFrame % totalFrames;

            spriteBatch.Begin();

            width = upLeftSprite.Width / numColumns;
            height = upLeftSprite.Height / numRows;
            spriteBatch.Draw(upLeftSprite, new Rectangle((int)position.X - xOffset, (int)position.Y - yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White);

            width = downLeftSprite.Width / numColumns;
            height = downLeftSprite.Height / numRows;
            spriteBatch.Draw(downLeftSprite, new Rectangle((int)position.X - xOffset, (int)position.Y + yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White);

            width = upRightSprite.Width / numColumns;
            height = upRightSprite.Height / numRows;
            spriteBatch.Draw(upRightSprite, new Rectangle((int)position.X + xOffset, (int)position.Y - yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White);

            width = downRightSprite.Width / numColumns;
            height = downRightSprite.Height / numRows;
            spriteBatch.Draw(downRightSprite, new Rectangle((int)position.X + xOffset, (int)position.Y + yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White);

            spriteBatch.End();
        }

        public bool FinishedAnimation()
        {
            return animationIsFinished;
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(); // because we do not need to check collisions for these
        }
    }
}
