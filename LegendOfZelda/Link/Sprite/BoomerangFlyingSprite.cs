using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    class BoomerangFlyingSprite : ILinkItemSprite
    {
        private readonly Texture2D sprite;
        private int bufferFrame;
        private int currentFrame;
        private const int totalFrames = 8;
        private const int numRows = 1;
        private const int numColumns = 8;

        public BoomerangFlyingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            bufferFrame = 0;
            currentFrame = 0;
        }

        public void Update()
        {
            if (++bufferFrame == Constants.FrameDelay)
            {
                currentFrame = currentFrame == totalFrames - 1 ? 0 : currentFrame + 1;
                bufferFrame = 0;
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
            int currentRow = 0;
            int currentColumn = currentFrame;

            Rectangle sourceRectangle = new Rectangle(width * currentColumn, height * currentRow, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public bool FinishedAnimation()
        {
            return false; // not used, BoomerangFlying class keeps track of this
        }
    }
}
