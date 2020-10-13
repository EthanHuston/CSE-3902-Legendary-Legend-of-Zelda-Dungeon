using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    class BombExplodingSprite : ILinkItemSprite
    {
        private readonly Texture2D sprite;
        private bool animationIsFinished;
        private int delayBeforeExplosionCounter;
        private int bufferFrame;
        private int currentFrame;
        private int totalFrames;
        private const int numRows = 1;
        private const int numColumns = 4;

        public BombExplodingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            delayBeforeExplosionCounter = 0;
            bufferFrame = 0;
            currentFrame = 0;
            totalFrames = numColumns * numRows;
        }

        public void Update()
        {
            if (FinishedAnimation()) return;
            if (++delayBeforeExplosionCounter > Constants.BombDelayBeforeExplosion && ++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            animationIsFinished = currentFrame >= totalFrames - 1;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Begin();
            Draw(spriteBatch, position, false);
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, bool drawWithDamage)
        {
            if (FinishedAnimation()) return;

            int width = sprite.Width / numColumns;
            int height = sprite.Height / numRows;
            int currentRow = 0;
            int currentColumn = currentFrame % totalFrames;

            Rectangle sourceRectangle = new Rectangle(width * currentColumn, height * currentRow, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public bool FinishedAnimation()
        {
            return animationIsFinished;
        }
    }
}
