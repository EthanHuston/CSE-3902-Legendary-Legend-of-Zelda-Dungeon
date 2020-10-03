using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0
{
    class BoomerangFlyingSprite : ISprite
    {
        private readonly Texture2D sprite;
        private int bufferFrame;
        private int currentFrame;
        private const int totalFrames = 7;
        private const int numRows = 1;
        private const int numColumns = 2;

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
                currentFrame = currentFrame == totalFrames ? 0 : currentFrame + 1;
                bufferFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = sprite.Width / numColumns;
            int height = sprite.Height / numRows;
            int currentRow = 1;
            int currentColumn = currentFrame;

            Rectangle sourceRectangle = new Rectangle(width * currentColumn, height * currentRow, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }


    }
}
