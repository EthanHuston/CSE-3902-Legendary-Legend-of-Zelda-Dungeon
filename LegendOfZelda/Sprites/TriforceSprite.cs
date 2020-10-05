using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    class TriforceSprite : ISprite
    {
        private Texture2D sprite;
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;
        public TriforceSprite(Texture2D sprite)
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
