using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class MerchantSprite : IItemSprite
    {
        private Texture2D sprite;
        private Rectangle destinationRectangle;

        public MerchantSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Update()
        {
            // no update needed
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            destinationRectangle = new Rectangle(position.X, position.Y, 2 * sprite.Width, 2 * sprite.Width);

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }
    }
}
