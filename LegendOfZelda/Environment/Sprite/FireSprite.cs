﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment.Sprite
{
    class FireSprite : ISprite
    {
        private const int numRows = 1;
        private const int numColumns = 2;
        private const int spriteScaler = 2;
        private Texture2D sprite;
        private int frameWidth;
        private int frameHeight;
        private int totalFrames;
        private Rectangle destinationRectangle;
        private int currentFrame;
        private int bufferFrame;

        public FireSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = numRows * numColumns;

            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;

            destinationRectangle = Rectangle.Empty;
        }
        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == 6)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            int row = (int)((float)currentFrame / (float)numColumns);
            int column = currentFrame % numColumns;
            Rectangle sourceRectangle = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);
            destinationRectangle = new Rectangle(position.X, position.Y, spriteScaler * frameWidth, spriteScaler * frameHeight);
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }

    }
}