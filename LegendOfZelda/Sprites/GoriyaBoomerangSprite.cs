using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Sprites
{
    class GoriyaBoomerangSprite : ISprite
    {
        private readonly Texture2D sprite;
        private int bufferFrame;
        private int currentFrame;
        private const int totalFrames = 8;
        private const int numRows = 1;
        private const int numColumns = 8;

        public GoriyaBoomerangSprite(Texture2D sprite)
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

        public void Draw(SpriteBatch spriteBatch, int posX, int posY)
        {
            int width = sprite.Width / numColumns;
            int height = sprite.Height / numRows;
            int currentRow = 1;
            int currentColumn = currentFrame;

            Rectangle sourceRectangle = new Rectangle(width * currentColumn, height * currentRow, width, height);
            Rectangle destinationRectangle = new Rectangle(posX, posY, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }


    }
}
