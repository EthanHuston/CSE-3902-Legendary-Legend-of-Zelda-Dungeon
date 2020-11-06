using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    internal class SpikeTrapSprite : IDamageableSprite
    {
        private readonly Texture2D sprite;

        public SpikeTrapSprite(Texture2D sprite)
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
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * sprite.Width), (int)(Constants.GameScaler * sprite.Height));

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged)
        {
            Draw(spriteBatch, position, false);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int) (sprite.Width * Constants.GameScaler), (int) (sprite.Height * Constants.GameScaler));
        }
    }
}
