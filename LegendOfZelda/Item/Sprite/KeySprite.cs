using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Item.Sprite
{
    class KeySprite : ISprite
    {
        private const int spriteScaler = 2;
        private Texture2D sprite;
        private Rectangle destinationRectangle;

        public KeySprite(Texture2D sprite)
        {
            this.sprite = sprite;
            destinationRectangle = Rectangle.Empty;
        }

        public void Update()
        {
            // No update needed for an unchanging object.
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            destinationRectangle = new Rectangle(position.X, position.Y, spriteScaler * sprite.Width, spriteScaler * sprite.Height);
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }

        public bool FinishedAnimation()
        {
            return false; // animation is never finished
        }
    }
}
