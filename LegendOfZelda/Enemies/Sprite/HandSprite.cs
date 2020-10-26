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
        private int spriteScaler = Constants.SpriteScaler;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;

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
