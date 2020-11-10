using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    internal class ArrowFlyingSprite : IProjectileSprite
    {
        private readonly Texture2D sprite;

        public ArrowFlyingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Rectangle destinationRectangle = new Rectangle(position, new Point((int)(sprite.Width * Constants.GameScaler), (int)(sprite.Height * Constants.GameScaler)));

            spriteBatch.Draw(sprite, destinationRectangle, Color.White);
        }

        public void Update()
        {
            // All updating is done in the class for this entity
        }

        public bool FinishedAnimation()
        {
            return false; // not used
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int) (sprite.Width * Constants.GameScaler), (int) (sprite.Height * Constants.GameScaler));
        }
    }
}
