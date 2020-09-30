using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0.Link.Sprite
{
    class BombExplodingSprite : ILinkItemSprite
    {
        private readonly Texture2D sprite;
        private bool animationIsFinished;
        private int delayBeforeExplosionCounter;
        private int bufferFrame;
        private int currentFrame;
        private const int totalFrames = 3;
        private const int numRows = 1;
        private const int numColumns = 2;

        public BombExplodingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            delayBeforeExplosionCounter = 0;
            bufferFrame = 0;
            currentFrame = 0;
        }

        public void Update()
        {
            if (++delayBeforeExplosionCounter > Constants.BombDelayBeforeExplosion && ++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            currentFrame = currentFrame == totalFrames ? 0 : currentFrame;

            animationIsFinished = currentFrame > totalFrames;
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
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public bool FinishedAnimation()
        {
            return animationIsFinished;
        }
    }
}
