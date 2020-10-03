using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0.Link.Sprite
{
    class SwordBeamExplodingSprite : ILinkItemSprite
    {
        private Texture2D spriteUpLeft, spriteDownLeft, spriteUpRight, spriteDownRight;
        private Vector2 originPosition;
        private bool animationIsFinished;
        private bool obtainedStartingPosition;
        private int xOffset;
        private int yOffset;
        private int bufferFrame;
        private int currentFrame;
        private const int totalFrames = 4;
        private const int numRows = 1;
        private const int numColumns = 2;

        public SwordBeamExplodingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            animationIsFinished = false;
            bufferFrame = 0;
            currentFrame = 0;
            xOffset = 0;
            yOffset = 0;
        }

        public void Update()
        {
            if (FinishedAnimation()) return;
            if (++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            xOffset += Constants.SwordBeamExplodingDistanceInterval;
            yOffset += Constants.SwordBeamExplodingDistanceInterval;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = sprite.Width / numColumns;
            int height = sprite.Height / numRows;
            int currentRow = 1;
            int currentColumn = currentFrame;

            animationIsFinished = Math.Sqrt(Math.Exp(xOffset, 2) + Math.Exp(yOffset, 2)) > Constants.SwordBeamExplodingRange;

            Rectangle sourceRectangle = new Rectangle(width * currentColumn, height * currentRow, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler));

            spriteBatch.Draw(spriteUpLeft, new Rectangle((int)position.X - xOffset, (int)position.Y - yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), sourceRectangle, Color.White);

            spriteBatch.Draw(spriteDownLeft, new Rectangle((int)position.X - xOffset, (int)position.Y + yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), sourceRectangle, Color.White);

            spriteBatch.Draw(spriteUpRight, new Rectangle((int)position.X + xOffset, (int)position.Y - yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), sourceRectangle, Color.White);

            spriteBatch.Draw(spriteDownRight, new Rectangle((int)position.X + xOffset, (int)position.Y + yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), sourceRectangle, Color.White);
        }

        public bool FinishedAnimation()
        {
            return animationIsFinished;
        }
    }
}
