using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment.Sprite
{
    class DoorSprite : ITextureAtlasSprite
    {
        private Texture2D sprite;
        private Rectangle destinationRectangle;

        public DoorSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            destinationRectangle = sprite.Bounds;
        }
        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Draw(spriteBatch, position, Point.Zero);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation)
        {
            int width = sprite.Width / 4;
            int height = sprite.Height / 4;
            destinationRectangle = new Rectangle(position.X, position.Y, width, height);
            Rectangle sourceRectangle = new Rectangle(width * textureLocation.X, height * textureLocation.Y, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }

        public void Update()
        {
            // no update needed
        }
    }
}
