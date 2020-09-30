using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0.Link.Sprite
{
    class WalkingLinkSprite : ILinkSprite
    {
        private readonly Texture2D sprite;
        private bool flashRed;
        private int damageColorCounter;
        private int bufferFrame;
        private int currentFrame;
        private const int totalFrames = 2;
        private const int numRows = 1;
        private const int numColumns = 2;

        public WalkingLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            flashRed = false;
            damageColorCounter = 0;
        }
        public void Update()
        {
            if (++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            currentFrame = currentFrame == totalFrames ? 0 : currentFrame;

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
            int width = sprite.Width / numColumns;
            int height = sprite.Height / numRows;
            int currentRow = 1;
            int currentColumn = currentFrame;

            Rectangle sourceRectangle = new Rectangle(width * currentColumn, height * currentRow, width, height);
            Rectangle destinationRectangle = new Rectangle((int) position.X, (int) position.Y, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, drawWithDamage && flashRed ? Color.Red : Color.White);
            spriteBatch.End();
        }

        public bool finishedAnimation()
        {
            return true; // because animation can be exited at any time
        }
    }
}
