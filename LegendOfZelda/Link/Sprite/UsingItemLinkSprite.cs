using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Link.Sprite
{
    class UsingItemLinkSprite : ILinkSprite
    {
        private Texture2D sprite;
        private bool flashRed;
        private int damageColorCounter;

        public UsingItemLinkSprite(Texture2D sprite)
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
    }
}
