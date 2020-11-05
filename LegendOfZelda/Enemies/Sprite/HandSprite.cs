using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    internal class HandSprite : IDamageableSprite
    {
        private readonly Texture2D sprite;
        private const int numRows = 2;
        private const int numColumns = 2;
        private int currentFrame;
        private int bufferFrame;
        private readonly bool currentDir;
        private readonly int rightRow;
        private readonly int leftRow;
        private bool flashRed;
        private int damageColorCounter;
        private readonly int width;
        private readonly int height;

        public HandSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            currentDir = true;
            rightRow = 0;
            leftRow = 0;
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
            if (currentFrame == 2)
            {
                currentFrame = 0;
            }
            if (++damageColorCounter == Constants.EnemyDamageFlashDelayTicks)
            {
                flashRed = !flashRed;
                damageColorCounter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Draw(spriteBatch, position, false);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged)
        {
            int row;
            if (currentDir)
            {
                row = rightRow;
            }
            else
            {
                row = leftRow;
            }

            int column = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * width), (int)(Constants.GameScaler * height));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, flashRed && damaged ? Color.Red : Color.White);
        }
        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(width * Constants.GameScaler), (int)(height * Constants.GameScaler));
        }
    }
}
