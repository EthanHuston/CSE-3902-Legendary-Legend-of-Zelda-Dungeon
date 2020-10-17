using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class HeartSprite : ISprite
    {
        private Texture2D sprite;
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;

        public HeartSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            Rows = 2;
            Columns = 1;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = Rows * Columns;
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
            int width = sprite.Width / (Columns * 3);
            int height = sprite.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, 2 * width, 2 * height);

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged)
        {
            Draw(spriteBatch, position);
        }
    }
}
