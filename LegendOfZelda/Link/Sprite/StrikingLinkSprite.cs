using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Link.Interface;

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

        public StrikingLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            animationIsDone = false;
            flashRed = false;
            damageColorCounter = 0;
        }

        public void Update()
        {
            animationIsDone = currentFrame >= totalFrames + Constants.LinkStrikingPauseTicks;
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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Begin();
            Draw(spriteBatch, position, false);
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, bool drawWithDamage)
        {
            int frameWidth = sprite.Width / numRows;
            int frameHeight = sprite.Height / numColumns;
            int currentRow = 1;
            int currentColumn = frameToCurrentColumnArray[currentFrame];

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(frameWidth * Constants.SpriteScaler), (int)(frameHeight * Constants.SpriteScaler));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, flashRed && drawWithDamage ? Color.White : Color.Red);
            spriteBatch.End();
        }

        public bool FinishedAnimation()
        {
            return animationIsDone;
        }
    }
}
