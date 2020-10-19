using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class StatueSprite : IItemSprite
    {
        private Texture2D sprite;
        public StatueSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, 2 * sprite.Width, 2 * sprite.Height);
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
