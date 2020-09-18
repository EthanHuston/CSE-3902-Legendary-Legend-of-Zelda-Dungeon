
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class NonMovingAnimatedSprite : ISprite
    {
        private Texture2D luigiWalkingStill;
        private SpriteBatch walkingStillSpriteBatch;
        //Animation code method taken from whitaker tutorials in Sprint0
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        public NonMovingAnimatedSprite(ContentManager content)
        {
            luigiWalkingStill = content.Load<Texture2D>("Image/LuigiWalkingStill");
            Rows = 1;
            Columns = 3;
            currentFrame = 0;
            totalFrames = Rows * Columns;

        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            walkingStillSpriteBatch = spriteBatch;
            int width = luigiWalkingStill.Width / Columns;
            int height = luigiWalkingStill.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(375, 200, 2 * width,2 * height);

            spriteBatch.Begin();
            spriteBatch.Draw(luigiWalkingStill, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();

        }
    }
}
