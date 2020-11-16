using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Item.Sprite
{
    internal class FairySprite : ISprite
    {
        private const int numRows = 1;
        private const int numColumns = 2;
        private readonly Texture2D sprite;
        private readonly int totalFrames;
        private readonly int frameWidth;
        private readonly int frameHeight;
        private int currentFrame;
        private int bufferFrame;
        private Point position;

        public FairySprite(Texture2D sprite, Point spawnPosition)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = numRows * numColumns;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;

            position = spawnPosition;
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

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            int row = (int)(currentFrame / (float)numColumns);
            int column = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * sprite.Width), (int)(Constants.GameScaler * sprite.Height));

            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int) (frameWidth * Constants.GameScaler), (int) (frameHeight * Constants.GameScaler));
        }
    }
}
