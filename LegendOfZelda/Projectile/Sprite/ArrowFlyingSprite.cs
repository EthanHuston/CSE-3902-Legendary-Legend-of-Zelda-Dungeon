using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Projectile.Sprite
{
    class ArrowFlyingSprite : IProjectileSprite
    {
        private Texture2D sprite;
        public ArrowFlyingSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position.ToVector2(), Color.White);
            spriteBatch.End();
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
            return sprite.Bounds;
        }
    }
}
