using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;

namespace Sprint0.Link.Sprite
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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, false);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, bool drawWithDamage)
        {
            spriteBatch.Draw(sprite, position, flashRed && drawWithDamage ? Color.Red : Color.White);
        }

        public bool FinishedAnimation()
        {
            return true; // because animation can be exited at any time
        }
    }
}
