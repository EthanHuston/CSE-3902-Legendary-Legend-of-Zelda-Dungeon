using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    class UsingItemLinkSprite : ILinkSprite
    {
        private Texture2D sprite;
        private bool animationIsDone;
        private bool flashRed;
        private int damageColorCounter;
        private int delayCounter;
        private Rectangle destinationRectangle;

        public UsingItemLinkSprite(Texture2D sprite)
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
            animationIsDone = delayCounter >= Constants.LinkUsingItemPauseTicks;
            if (FinishedAnimation()) return;
            delayCounter++;

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
            destinationRectangle = new Rectangle(position.X, position.Y, sprite.Width, sprite.Height);

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, flashRed && drawWithDamage ? Color.Red : Color.White);
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
