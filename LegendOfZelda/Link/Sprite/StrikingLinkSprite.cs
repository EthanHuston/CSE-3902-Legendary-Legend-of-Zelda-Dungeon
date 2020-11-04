using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    internal class StrikingLinkSprite : ILinkSprite
    {
        private readonly Texture2D sprite;
        private bool animationIsDone;
        private bool flashRed;
        private int damageColorCounter;
        private int currentFrame;
        private int bufferFrame;
        private readonly int frameWidth;
        private readonly int frameHeight;
        private readonly int[] frameToCurrentColumnArray = { 0, 1, 2, 3, 2, 1, 0 };
        private readonly int totalFrames;
        private const int numRows = 2;
        private const int numColumns = 4;

        public StrikingLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            animationIsDone = false;
            flashRed = false;
            damageColorCounter = 0;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;
            totalFrames = frameToCurrentColumnArray.Length;
        }

        public void Update()
        {
            animationIsDone = currentFrame >= totalFrames - 1;
            if (FinishedAnimation()) return;

            // Check to see if we're at total frames so animation doesn't loop
            if (currentFrame < totalFrames && ++bufferFrame == LinkConstants.UsingSwordFrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            if (++damageColorCounter == LinkConstants.DamageFlashDelayTicks)
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
            int currentRow = 1;
            int currentColumn = frameToCurrentColumnArray[currentFrame];

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, flashRed && drawWithDamage ? Color.Red : Color.White);
        }

        public bool FinishedAnimation()
        {
            return animationIsDone;
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));
        }
    }
}
