using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Link.Sprite
{
    class PickingUpItemLinkSprite : ILinkSprite
    {
        private Texture2D sprite;
        private bool animationIsDone;
        private bool flashRed;
        private int damageColorCounter;
        private int currentFrame;
        private int bufferFrame;
        private const int totalFrames = 2;
        private const int numRows = 1;
        private const int numColumns = 2;

        public PickingUpItemLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            animationIsDone = false;
            flashRed = false;
            damageColorCounter = 0;
        }

        public void Update()
        {
            if (finishedAnimation()) return;

            animationIsDone = currentFrame >= totalFrames + Constants.LinkPickingUpItemPauseTicks;
            currentFrame += bufferFrame++ == Constants.FrameDelay ? 1 : 0;

            if (++damageColorCounter == Constants.LinkDamageFlashDelayTicks)
            {
                flashRed = !flashRed;
                damageColorCounter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, false);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, bool drawWithDamage)
        {
            if (finishedAnimation()) return;

            int frameWidth = sprite.Width / numRows;
            int frameHeight = sprite.Height / numColumns;
            int currentRow = 1;
            int currentColumn = currentFrame;

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(frameWidth * Constants.SpriteScaler), (int)(frameHeight * Constants.SpriteScaler));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, flashRed && drawWithDamage ? Color.White : Color.Red);
            spriteBatch.End();
        }

        public bool finishedAnimation()
        {
            return animationIsDone;
        }
    }
}
