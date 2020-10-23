using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item.Sprite
{
    class RupeeSprite : ISprite
    {
        private Texture2D sprite;
        private const int numRows = 2;
        private const int numColumns = 1;
        private const int spriteScaler = 2;
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;
        private Rectangle destinationRectangle;

        public RupeeSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = numRows * numColumns;
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
            int width = sprite.Width / numColumns;
            int height = sprite.Height / numRows;
            int row = (int)(currentFrame / numColumns);
            int column = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            destinationRectangle = new Rectangle(position.X, position.Y, spriteScaler * width, spriteScaler * height);

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }
    }
}
