using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    class BatSprite : IDamageableSprite
    {
        private Texture2D sprite;
        private const int numRows = 1;
        private const int numColumns = 2;
        private const int frameDelay = 30;
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;
        private int spriteScaler = Constants.SpriteScaler;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

        public BatSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = numRows * numColumns;
        }

        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == frameDelay)
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
            Draw(spriteBatch, position, false);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged)
        {
            int width = sprite.Width / numColumns;
            int height = sprite.Height / numRows;
            int row = (int)((float)currentFrame / (float)numColumns);
            int column = currentFrame % numColumns;

            sourceRectangle = new Rectangle(width * column, height * row, width, height);
            destinationRectangle = new Rectangle(position.X, position.Y, spriteScaler * width, spriteScaler * height);

            if (damaged)
            {
                spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.Red);
            }
            else
            {
                spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            }
        }
        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }
    }
}
