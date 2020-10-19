using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    class PickingUpTriforceLinkSprite : ILinkSprite
    {
        private Texture2D sprite;
        private bool animationIsDone;
        private bool flashRed;
        private int damageColorCounter;
        private int currentFrame;
        private int bufferFrame;
        private int delayCounter;
        private Rectangle destinationRectangle;
        private const int numRows = 1;
        private const int numColumns = 2;

        public PickingUpTriforceLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            animationIsDone = false;
            flashRed = false;
            damageColorCounter = 0;
            delayCounter = 0;
            destinationRectangle = Rectangle.Empty;
        }

        public void Update()
        {
            animationIsDone = delayCounter >= Constants.LinkPickingUpItemPauseTicks;
            if (FinishedAnimation()) return;
            delayCounter++;

            if (++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            if (++damageColorCounter == Constants.LinkDamageFlashDelayTicks)
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
            if (FinishedAnimation()) return;

            int frameWidth = sprite.Width / numColumns;
            int frameHeight = sprite.Height / numRows;
            int currentRow = 0;
            int currentColumn = currentFrame % 2;

            Rectangle sourceRectangle = new Rectangle(frameWidth * currentColumn, frameHeight * currentRow, frameWidth, frameHeight);
            destinationRectangle = new Rectangle(position.X, position.Y, (int)(frameWidth * Constants.SpriteScaler), (int)(frameHeight * Constants.SpriteScaler));

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, flashRed && drawWithDamage ? Color.Red : Color.White);
            spriteBatch.End();
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
