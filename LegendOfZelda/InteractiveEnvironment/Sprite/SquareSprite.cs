using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.InteractiveEnvironment.Sprite
{
    class SquareSprite : IItemSprite
    {
        private Texture2D sprite;
        private Rectangle destinationRectangle;

        public SquareSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            destinationRectangle = sprite.Bounds;
        }
        public void Update()
        {
            // nothing to do
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            destinationRectangle = new Rectangle(position.X, position.Y, 2 * sprite.Width, 2 * sprite.Height);
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
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
