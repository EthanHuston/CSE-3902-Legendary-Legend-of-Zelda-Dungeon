using LegendOfZelda.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    class SwordAttackingSprite : IProjectileSprite
    {
        private Texture2D sprite;
        private bool animationIsDone;
        private int currentFrame;
        private int bufferFrame;
        private readonly int[] frameToCurrentColumnArray = { 0, 1, 2, 3, 2, 1, 0 };
        private const int totalFrames = 7;
        private const int numRows = 2;
        private const int numColumns = 4;
        private Rectangle destinationRectangle;

        public SwordAttackingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            animationIsDone = false;
            destinationRectangle = Rectangle.Empty;
        }

        public void Update()
        {
            animationIsDone = currentFrame >= totalFrames - 1;
            if (FinishedAnimation()) return;

            // Check to see if we're at total frames so animation doesn't loop
            if (currentFrame < totalFrames && ++bufferFrame == LinkConstants.UsingSwordFrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            int frameWidth = sprite.Width / numColumns;
            int frameHeight = sprite.Height / numRows;
            int currentRow = 0;
            int currentColumn = frameToCurrentColumnArray[currentFrame];

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public bool FinishedAnimation()
        {
            return animationIsDone;
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }
    }
}
