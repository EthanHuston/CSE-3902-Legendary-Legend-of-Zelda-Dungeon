using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment.Sprite
{
    internal class StairSprite : ISprite
    {
        private readonly Texture2D sprite;
        private Rectangle destinationRectangle;
        public StairSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            destinationRectangle = Rectangle.Empty;
        }
        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            destinationRectangle = new Rectangle(position.X, position.Y, RoomConstants.SpriteMultiplier * sprite.Width, RoomConstants.SpriteMultiplier * sprite.Height);
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {

        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }
    }
}
