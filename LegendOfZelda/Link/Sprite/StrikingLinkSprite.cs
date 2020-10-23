using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    class StrikingLinkSprite : ILinkSprite
    {
        private Texture2D sprite;
        private bool animationIsDone;
        private bool flashRed;
        private int damageColorCounter;
        private int currentFrame;
        private int bufferFrame;
        private readonly int[] frameToCurrentColumnArray = { 0, 1, 2, 3, 2, 1, 0 };
        private const int totalFrames = 7;
        private const int numRows = 1;
        private const int numColumns = 4;
        private Rectangle destinationRectangle;

        public StrikingLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            animationIsDone = false;
            flashRed = false;
            damageColorCounter = 0;
            destinationRectangle = Rectangle.Empty;
        }

        public void Update()
        {
            animationIsDone = currentFrame >= totalFrames - 1;
            if (FinishedAnimation()) return;

            // Check to see if we're at total frames so animation doesn't loop
            if (currentFrame < totalFrames && ++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

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
            int frameWidth = sprite.Width / numColumns;
            int frameHeight = sprite.Height / numRows;
            int currentRow = 1;
            int currentColumn = frameToCurrentColumnArray[currentFrame];

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, flashRed && drawWithDamage ? Color.Red : Color.White);
        }

        public bool FinishedAnimation()
        {
            return animationIsDone;
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }
    }
}
