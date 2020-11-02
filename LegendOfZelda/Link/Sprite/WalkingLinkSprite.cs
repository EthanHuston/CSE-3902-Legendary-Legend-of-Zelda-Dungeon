using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    internal class WalkingLinkSprite : ILinkSprite
    {
        private readonly Texture2D sprite;
        private bool flashRed;
        private bool animationIsDone;
        private int damageColorCounter;
        private int bufferFrame;
        private int currentFrame;
        private readonly int spriteWidth;
        private readonly int spriteHeight;
        private const int totalFrames = 2;
        private const int numRows = 1;
        private const int numColumns = 2;
        private const int walkingFrameDelay = 10;

        public WalkingLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            flashRed = false;
            damageColorCounter = 0;
            bufferFrame = 0;
            currentFrame = 0;
            spriteWidth = (int)(sprite.Width / numColumns * Constants.GameScaler);
            spriteHeight = (int)(sprite.Height / numRows * Constants.GameScaler);
        }

        public void Update()
        {
            animationIsDone = currentFrame >= totalFrames;
            if (FinishedAnimation()) return;

            currentFrame += ++bufferFrame % walkingFrameDelay == 0 ? 1 : 0;

            if (++damageColorCounter == LinkConstants.DamageFlashDelayTicks)
            {
                flashRed = !flashRed;
                damageColorCounter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Draw(spriteBatch, position, false);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool drawWithDamage)
        {
            int currentRow = 0;
            int currentColumn = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(spriteWidth * currentColumn, spriteHeight * currentRow, spriteWidth, spriteHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(spriteWidth * Constants.GameScaler), (int)(spriteHeight * Constants.GameScaler));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, drawWithDamage && flashRed ? Color.Red : Color.White);
        }

        public bool FinishedAnimation()
        {
            return animationIsDone;
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, spriteWidth, spriteHeight);
        }
    }
}
