using LegendOfZelda.Sprint2;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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
        private int movementBuffer = 0;
        private int xDir = 0;
        private int yDir = 0;
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
            movementBuffer++;
            CheckBounds();
            //Move based on current chosen direction for some time.
            if (xDir == 0 && yDir == 0)
            {
                currentXVal--;
                currentYVal--;
            }
            else if (xDir == 0 && yDir == 1)
            {
                currentXVal--;
                currentYVal++;
            }
            else if (xDir == 1 && yDir == 0)
            {
                currentXVal++;
                currentYVal--;
            }
            else
            {
                currentYVal++;
                currentXVal++;
            }

            if (movementBuffer > 10)
            {
                movementBuffer = 0;
                ChooseDirection();
            }
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
            Rectangle destinationRectangle = new Rectangle(currentXVal, currentYVal, (int)(1.25 * sprite.Width), (int)(1.25 * sprite.Height));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        private void CheckBounds()
        {
            if (currentXVal == minXVal)
            {
                currentXVal = currentXVal + 5;
            }
            else if (currentXVal == maxXVal)
            {
                currentXVal = currentXVal - 5; ;
            }
            else if (currentYVal == minYVal)
            {
                currentYVal = currentYVal + 5; ;
            }
            else if (currentYVal == maxYVal)
            {
                currentYVal = currentYVal - 5;
            }
        }
        private void ChooseDirection()
        {
            Random rand = new Random();
            xDir = rand.Next(0, 2); // 0 for x, 1 for y
            yDir = rand.Next(0, 2); // 0 right/down. 1 for left/up
        }
    }
}
