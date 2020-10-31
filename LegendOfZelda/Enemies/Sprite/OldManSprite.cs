using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Enemies.Sprite
{
    class OldManSprite : ISprite
    {
        private Texture2D sprite;
        private Rectangle destinationRectangle;

        public OldManSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            destinationRectangle = Rectangle.Empty;
        }
        public void Update()
        {
            // no update needed
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            destinationRectangle = new Rectangle(position.X, position.Y, (int) (Constants.GameScaler * sprite.Width), (int) (Constants.GameScaler * sprite.Width));
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }
    }
}
