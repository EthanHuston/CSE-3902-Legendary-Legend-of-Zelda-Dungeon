using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    class IdleLinkSprite : ILinkSprite
    {
        private Texture2D sprite;
        private bool flashRed;
        private int damageColorCounter;

        public IdleLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            flashRed = false;
            damageColorCounter = 0;
        }

        public void Update()
        {
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
            Rectangle destinationRectangle = new Rectangle(position, new Point(sprite.Width, sprite.Height));

            spriteBatch.Draw(sprite, destinationRectangle, flashRed && drawWithDamage ? Color.Red : Color.White);
        }

        public bool FinishedAnimation()
        {
            return true; // because animation can be exited at any time
        }

        public Rectangle GetPositionRectangle()
        {
            return sprite.Bounds;
        }
    }
}
