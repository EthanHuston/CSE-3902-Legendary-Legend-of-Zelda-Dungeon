using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item.Sprite
{
    class HeartSprite : ISprite
    {
        private const int numRows = 2;
        private const int numColumns = 1;
        private Texture2D sprite;
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;
        private Rectangle destinationRectangle;

        public HeartSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = numRows * numColumns;
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
            int width = sprite.Width / (numColumns * 3);
            int height = sprite.Height / numRows;
            int row = (int)((float)currentFrame / (float)numColumns);
            int column = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            destinationRectangle = new Rectangle(position.X, position.Y, 2 * width, 2 * height);

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged)
        {
            Draw(spriteBatch, position);
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }

        public bool FinishedAnimation()
        {
            return false; // animation is never finished
        }
    }
}
