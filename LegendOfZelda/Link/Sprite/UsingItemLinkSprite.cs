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

        public UsingItemLinkSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            animationIsDone = false;
            flashRed = false;
            damageColorCounter = 0;
            delayCounter = 0;
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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, false);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, bool drawWithDamage)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position, flashRed && drawWithDamage ? Color.Red : Color.White);
            spriteBatch.End();
        }

        public bool FinishedAnimation()
        {
            return animationIsDone;
        }
    }
}
