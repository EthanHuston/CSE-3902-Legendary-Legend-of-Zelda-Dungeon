using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class MovingAnimatedSprite : ISprite
    {
        private Texture2D luigiWalkingLeft;
        private Texture2D luigiWalkingRight;
        private SpriteBatch walkingSpriteBatch;
        //Animation code method taken from whitaker tutorials in Sprint0
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int currentXVal;
        private int maxXVal;
        private int minXVal;
        private bool currentDirection;

        public MovingAnimatedSprite(ContentManager content)
        {
            luigiWalkingLeft = content.Load<Texture2D>("Image/LuigiWalkingLeft");
            luigiWalkingRight = content.Load<Texture2D>("Image/LuigiWalkingRight");
           
            Rows = 1;
            Columns = 3;
            currentFrame = 0;
            totalFrames = Rows * Columns;

            currentXVal = 375;
            maxXVal = 600;
            minXVal = 100;
            currentDirection = true;
        }

        public void Update()
        {
            //Updating Walking position and/or direction
            if (currentDirection)
            {
                currentXVal++;
                if (currentXVal >= maxXVal)
                {
                    currentDirection = false;
                }
            }
            else
            {
                currentXVal--;
                if (currentXVal <= minXVal)
                {
                    currentDirection = true;
                }
            }

            //Updating animation frames
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            walkingSpriteBatch = spriteBatch;
            int width = luigiWalkingLeft.Width / Columns;
            int height = luigiWalkingLeft.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(currentXVal, 200, 2 * luigiWalkingLeft.Width, 2 * luigiWalkingLeft.Height);

            spriteBatch.Begin();
            if (currentDirection)
            {
                spriteBatch.Draw(luigiWalkingRight, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(luigiWalkingLeft, destinationRectangle, sourceRectangle, Color.White);
            }
            
            spriteBatch.End();

        }
    }
}
