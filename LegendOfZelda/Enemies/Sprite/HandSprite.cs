using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    class HandSprite : IDamageableSprite
    {
        private Texture2D sprite;
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private bool currentDir;
        private int rightRow;
        private int leftRow;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private bool flashRed;
        private int damageColorCounter;

        public HandSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            Rows = 2;
            Columns = 2;
            currentFrame = 0;
            bufferFrame = 0;
            currentDir = true;
            rightRow = 0;
            leftRow = 0;
            flashRed = false;
            damageColorCounter = 0;
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
            int width = sprite.Width / Columns;
            int height = sprite.Height / Rows;
            int row;
            if (currentDir)
            {
                row = rightRow;
            }
            else
            {
                row = leftRow;
            }

            int column = currentFrame % Columns;

            sourceRectangle = new Rectangle(width * column, height * row, width, height);
            destinationRectangle = new Rectangle(position.X, position.Y, (int) (Constants.GameScaler * width), (int) (Constants.GameScaler * height));
            
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, flashRed && damaged ? Color.Red : Color.White);
        }
        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }
    }
}
