﻿using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    internal class BombExplodingSprite : IProjectileSprite
    {
        private readonly Texture2D sprite;
        private bool animationIsFinished;
        private int delayBeforeExplosionCounter;
        private int bufferFrame;
        private int currentFrame;
        private readonly int totalFrames;
        private const int numRows = 1;
        private const int numColumns = 7;
        private const int delayBeforeExplosion = 60;
        private bool isExploding;
        private readonly int width;
        private readonly int height;

        public BombExplodingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            delayBeforeExplosionCounter = 0;
            bufferFrame = 0;
            currentFrame = 0;
            isExploding = false;
            width = sprite.Width / numColumns;
            height = sprite.Height / numRows;
            totalFrames = numRows * numColumns;
        }

        public void Update()
        {
            if (FinishedAnimation()) return;
            if (++delayBeforeExplosionCounter > delayBeforeExplosion && ++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
                isExploding = true;
            }

            animationIsFinished = currentFrame >= totalFrames - 1;
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            if (FinishedAnimation()) return;

            int currentRow = 0;
            int currentColumn = currentFrame % totalFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentColumn, height * currentRow, width, height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(width * Constants.GameScaler), (int)(height * Constants.GameScaler));

            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }

        public bool FinishedAnimation()
        {
            return animationIsFinished;
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(width * Constants.GameScaler), (int)(height * Constants.GameScaler));
        }

        public bool IsExploding()
        {
            return isExploding;
        }
    }
}
