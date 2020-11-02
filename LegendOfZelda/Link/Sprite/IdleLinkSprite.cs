using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Sprite
{
    internal class IdleLinkSprite : ILinkSprite
    {
        private readonly Texture2D sprite;
        private bool flashRed;
        private int damageColorCounter;
        private readonly int spriteWidth;
        private readonly int spriteHeight;

        public IdleLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            flashRed = false;
            damageColorCounter = 0;
            spriteWidth = (int)(sprite.Width * Constants.GameScaler);
            spriteHeight = (int)(sprite.Height * Constants.GameScaler);
        }

        public void Update()
        {
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
            Rectangle destinationRectangle = new Rectangle(position, new Point(((int)Constants.GameScaler * sprite.Width), ((int)Constants.GameScaler * sprite.Height)));

            spriteBatch.Draw(sprite, destinationRectangle, flashRed && drawWithDamage ? Color.Red : Color.White);
        }

        public bool FinishedAnimation()
        {
            return true; // because animation can be exited at any time
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, spriteWidth, spriteHeight);
        }
    }
}
