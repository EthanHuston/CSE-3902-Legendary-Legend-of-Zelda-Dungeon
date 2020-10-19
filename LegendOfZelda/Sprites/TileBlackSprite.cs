using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class TileBlackSprite : ISprite
    {
        private Texture2D sprite;
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;

        public TileBlackSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            // No update needed for an unchanging object.
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            destinationRectangle = new Rectangle(position.X, position.Y, sprite.Width, sprite.Height);
            sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        Rectangle ISprite.GetPositionRectangle()
        {
            return destinationRectangle;
        }
    }
}
