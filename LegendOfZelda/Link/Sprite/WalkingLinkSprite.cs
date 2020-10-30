using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    class WalkingLinkSprite : ILinkSprite
    {
        private readonly Texture2D sprite;
        private bool flashRed;
        private int damageColorCounter;
        private int bufferFrame;
        private int currentFrame;
        private int frameWidth;
        private int frameHeight;
        private const int totalFrames = 2;
        private const int numRows = 1;
        private const int numColumns = 2;
        private const int walkingFrameDelay = 7;

        public WalkingLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            flashRed = false;
            damageColorCounter = 0;
            bufferFrame = 0;
            currentFrame = 0; frameWidth = sprite.Width / numColumns; 
            frameHeight = sprite.Height / numRows;
        }

        public void Update()
        {
            currentFrame += ++bufferFrame % walkingFrameDelay == 0 ? 1 : 0; 

            if (++damageColorCounter == Constants.LinkDamageFlashDelayTicks)
            {
                flashRed = !flashRed;
                damageColorCounter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Draw(spriteBatch, position, false);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool drawWithDamage)
        {
            int currentRow = 0;
            int currentColumn = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, drawWithDamage && flashRed ? Color.Red : Color.White);
        }

        public bool FinishedAnimation()
        {
            return false; // because animation can be exited at any time
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, frameWidth, frameHeight);
        }
    }
}
