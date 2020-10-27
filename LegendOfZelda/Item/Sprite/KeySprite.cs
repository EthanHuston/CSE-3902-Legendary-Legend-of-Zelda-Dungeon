using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item.Sprite
{
    internal class KeySprite : ISprite
    {
        private readonly Texture2D sprite;

        public KeySprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Update()
        {
            // No update needed for an unchanging object.
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, Constants.SpriteScaler * sprite.Width, Constants.SpriteScaler * sprite.Height);
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetPositionRectangle()
        {
            return sprite.Bounds;
        }

        public bool FinishedAnimation()
        {
            return false; // animation is never finished
        }
    }
}
