using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Projectile.Sprite
{
    internal class SwordBeamExplodingSprite : IProjectileSprite
    {
        private readonly Texture2D upLeftSprite, upRightSprite, downLeftSprite, downRightSprite;
        private bool animationIsFinished;
        private int xOffset;
        private int yOffset;
        private int bufferFrame;
        private int currentFrame;
        private readonly int totalFrames;
        private const int frameDelay = 2;
        private const int numRows = 1;
        private const int numColumns = 4;
        private const int explosionDistanceVelocity = (int)(Constants.GameScaler * 1);
        private const int explosionRange = (int)(30 * Constants.GameScaler);

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

            xOffset += explosionDistanceVelocity;
            yOffset += explosionDistanceVelocity;

            animationIsFinished = Math.Sqrt(Math.Pow(xOffset, 2) + Math.Pow(yOffset, 2)) > explosionRange;
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            int width, height;
            int currentRow = 0;
            int currentColumn = currentFrame % totalFrames;

            width = upLeftSprite.Width / numColumns;
            height = upLeftSprite.Height / numRows;
            SimpleDraw.Draw(spriteBatch, upLeftSprite, new Rectangle(position.X - xOffset, position.Y - yOffset, (int)(width * Constants.GameScaler), (int)(height * Constants.GameScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White, layer);

            width = downLeftSprite.Width / numColumns;
            height = downLeftSprite.Height / numRows;
            SimpleDraw.Draw(spriteBatch, downLeftSprite, new Rectangle(position.X - xOffset, position.Y + yOffset, (int)(width * Constants.GameScaler), (int)(height * Constants.GameScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White, layer);

            width = upRightSprite.Width / numColumns;
            height = upRightSprite.Height / numRows;
            SimpleDraw.Draw(spriteBatch, upRightSprite, new Rectangle(position.X + xOffset, position.Y - yOffset, (int)(width * Constants.GameScaler), (int)(height * Constants.GameScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White, layer);

            width = downRightSprite.Width / numColumns;
            height = downRightSprite.Height / numRows;
            SimpleDraw.Draw(spriteBatch, downRightSprite, new Rectangle(position.X + xOffset, position.Y + yOffset, (int)(width * Constants.GameScaler), (int)(height * Constants.GameScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White, layer);
        }

        public bool FinishedAnimation()
        {
            return animationIsFinished;
        }

        public Rectangle GetPositionRectangle()
        {
            return Rectangle.Empty;
        }
    }
}
