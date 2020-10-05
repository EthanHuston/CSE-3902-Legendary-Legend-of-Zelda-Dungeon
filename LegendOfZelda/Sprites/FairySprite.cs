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
    class FairySprite : ISprite
    {
        private Texture2D sprite;
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private int totalFrames;
        private int currentXVal;
        private int currentYVal;
        private int maxXVal;
        private int maxYVal;
        private int minXVal;
        private int minYVal;
        public FairySprite(Texture2D sprite)
        {
            this.sprite = sprite;
            Rows = 1;
            Columns = 2;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = Rows * Columns;

            currentXVal = ConstantsSprint2.itemX;
            currentYVal = ConstantsSprint2.itemY;

            maxXVal = 800;
            maxYVal = 480;
            minXVal = 0;
            minYVal = 0;
        }
        public void Update()
        {
            // "Random" movement of the Fairy:
            if (currentXVal == minXVal)
            {
                currentXVal++;
            }
            else if (currentXVal == maxXVal)
            {
                currentXVal--;
            }
            else if (currentYVal == minYVal)
            {
                currentYVal++;
            }
            else if(currentYVal == maxYVal)
            {
                currentYVal--;
            }
            else
            {
                Random rand = new Random();
                int xy = rand.Next(0, 1); // 0 for x, 1 for y
                int pn = rand.Next(0, 1); // 0 right/down. 1 for left/up

                if (xy == 0 && pn == 0)
                {
                    currentXVal++;
                }
                else if (xy == 0 && pn == 1)
                {
                    currentXVal--;
                }
                else if (xy == 1 && pn == 0)
                {
                    currentYVal++;
                }
                else
                {
                    currentYVal--;
                }
            }

            // For frame rate of the Fairy:
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
            Rectangle destinationRectangle = new Rectangle(currentXVal, currentYVal,(int) (1.25 * sprite.Width), (int)(1.25 * sprite.Height));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
