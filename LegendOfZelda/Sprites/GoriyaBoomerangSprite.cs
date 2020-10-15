using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Sprites
{
    class GoriyaBoomerangSprite : ISprite
    {
        private readonly Texture2D sprite;
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;

        public GoriyaBoomerangSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            Rows = 1;
            Columns = 8;
            bufferFrame = 0;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == 2)
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
            //Not needed for this object.
        }
        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue)
        {
            int width = sprite.Width / Columns;
            int height = sprite.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(XValue, YValue, 2 * width, 2 * height);

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }


    }
}
