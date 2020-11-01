using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    internal class JellySprite : IDamageableSprite
    {
        private const int numRows = 1;
        private const int numColumns = 2;
        private readonly Texture2D sprite;
        private int currentFrame;
        private int bufferFrame;
        private readonly int totalFrames;
        private bool flashRed;
        private int damageColorCounter;
        private readonly int width;
        private readonly int height;

        public JellySprite(Texture2D sprite)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = numRows * numColumns;
            flashRed = false;
            damageColorCounter = 0;
            width = sprite.Width / numColumns;
            height = sprite.Height / numRows;
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
            if (++damageColorCounter == Constants.EnemyDamageFlashDelayTicks)
            {
                flashRed = !flashRed;
                damageColorCounter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged)
        {
            int row = currentFrame % numRows;
            int column = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * width), (int)(Constants.GameScaler * height));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, flashRed && damaged ? Color.Red : Color.White);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, width, height);
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Draw(spriteBatch, position, false);
        }
    }
}
