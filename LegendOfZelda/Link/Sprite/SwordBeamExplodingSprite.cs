using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Link.Sprite
{
    class SwordBeamExplodingSprite : ILinkItemSprite
    {
        private Texture2D upLeftSprite, upRightSprite, downLeftSprite, downRightSprite;
        private bool animationIsFinished;
        private int xOffset;
        private int yOffset;
        private int bufferFrame;
        private int currentFrame;
        private int totalFrames;
        private const int numRows = 1;
        private const int numColumns = 4;

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
            if (++bufferFrame == Constants.SwordBeamExplodingFrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            xOffset += Constants.SwordBeamExplodingDistanceInterval;
            yOffset += Constants.SwordBeamExplodingDistanceInterval;

            animationIsFinished = Math.Sqrt(Math.Pow(xOffset, 2) + Math.Pow(yOffset, 2)) > Constants.SwordBeamExplodingRange;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
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
    }
}
