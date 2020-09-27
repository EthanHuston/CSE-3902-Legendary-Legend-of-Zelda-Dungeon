using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class WalkingDownDamagedLinkSprite : ISprite
    {
        private Texture2D sprite;
        private int bufferFrame;
        private int currentFrame;
        private const int totalFrames = 2;
        private const int frameDelay = 5;
        public WalkingDownDamagedLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == frameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            currentFrame = currentFrame == totalFrames ? 0 : currentFrame;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = sprite.Width / Columns;
            int height = sprite.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(currentXVal, currentYVal, 2 * sprite.Width, 2 * sprite.Height);

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
            spriteBatch.Draw(sprite, new Vector2(Constants.Sprint2LinkSpawnX, Constants.Sprint2LinkSpawnY), currentFrame == 0 ? Color.White : Color.Red);
        }
    }
}
