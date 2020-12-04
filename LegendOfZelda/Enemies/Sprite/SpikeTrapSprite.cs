using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
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

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * sprite.Width), (int)(Constants.GameScaler * sprite.Height));

            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, bool damaged, float layer)
        {
            Draw(spriteBatch, position, false, layer);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(sprite.Width * Constants.GameScaler), (int)(sprite.Height * Constants.GameScaler));
        }
    }
}
