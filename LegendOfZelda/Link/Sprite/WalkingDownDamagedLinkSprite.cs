using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Link.Sprite
{
    class WalkingDownDamagedLinkSprite : ISprite
    {
        private Texture2D sprite;
        private int bufferFrame;
        private int currentFrame;
        private readonly int totalFrames;
        private int xPos;
        private int yPos;
        private const int rows = 1;
        private const int columns = 2;

        public WalkingDownDamagedLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            totalFrames = rows * columns;
            xPos = Constants.Sprint2LinkSpawnX;
            yPos = Constants.Sprint2LinkSpawnY;
        }
        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            currentFrame = currentFrame == totalFrames ? 0 : currentFrame;

            // Update position - don't move if at edge of screen
            /* Not needed for sprint 2
            yPos += yPos < Constants.MaxYPos ? Constants.LinkWalkDistance : 0;
            */
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = sprite.Width / columns;
            int height = sprite.Height / rows;
            int row = 1;
            int column = currentFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(xPos, yPos, (int) (width * Constants.SpriteScaler), (int) (height * Constants.SpriteScaler));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, currentFrame % 2 == 0 ? Color.White : Color.Red);
            spriteBatch.End();
        }
    }
}
