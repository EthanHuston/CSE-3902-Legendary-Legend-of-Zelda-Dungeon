using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Sprite
{
    class SwordBeamFlyingSprite : ILinkItemSprite
    {
        private readonly Texture2D sprite;
        private int bufferFrame;
        private int currentFrame;
        private int totalFrames;
        private const int numRows = 1;
        private const int numColumns = 4;

        public SwordBeamFlyingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            bufferFrame = 0;
            currentFrame = 0;
            totalFrames = numColumns * numRows;
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
