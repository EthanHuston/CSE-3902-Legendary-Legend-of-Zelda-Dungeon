using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class AquamentusBreathingSprite : ISprite
    {
        private Texture2D sprite;
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;

        public AquamentusBreathingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            Rows = 1;
            Columns = 2;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = Rows * Columns;
        }
        public void Update()
        {
            bufferFrame++;
            if(bufferFrame == 6)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            if(currentFrame == totalFrames)
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
