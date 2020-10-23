using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    class ArrowFlyingSprite : IProjectileSprite
    {
        private Texture2D sprite;
        private Rectangle destinationRectangle;

        public ArrowFlyingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            destinationRectangle = Rectangle.Empty;
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            destinationRectangle = new Rectangle(position, new Point(sprite.Width, sprite.Height));

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
            return destinationRectangle;
        }
    }
}
