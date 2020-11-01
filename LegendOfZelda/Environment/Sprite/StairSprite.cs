using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment.Sprite
{
    internal class StairSprite : ISprite
    {
        private readonly Texture2D sprite;
        public StairSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(RoomConstants.SpriteMultiplier * sprite.Width), (int)(RoomConstants.SpriteMultiplier * sprite.Height));
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            // nothing to do
        }

        public Rectangle GetPositionRectangle()
        {
            return sprite.Bounds;
        }
    }
}
