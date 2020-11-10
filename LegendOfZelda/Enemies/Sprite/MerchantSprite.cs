using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    internal class MerchantSprite : ISprite
    {
        private readonly Texture2D sprite;

        public MerchantSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Update()
        {
            // no update needed
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, sprite.Width, sprite.Width);

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(sprite.Width * Constants.GameScaler), (int)(sprite.Height * Constants.GameScaler));
        }
    }
}
