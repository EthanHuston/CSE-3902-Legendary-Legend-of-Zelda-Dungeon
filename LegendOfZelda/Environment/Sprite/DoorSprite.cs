using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment.Sprite
{
    class DoorSprite : ITextureAtlasSprite
    {
        private Texture2D sprite;
        private int frameWidth;
        private int frameHeight;

        public DoorSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            frameWidth = sprite.Width / 4;
            frameHeight = sprite.Height / 4;
        }
        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Draw(spriteBatch, position, Point.Zero);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation)
        {
            int width = sprite.Width / 4;
            int height = sprite.Height / 4;
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, width, height);
            Rectangle sourceRectangle = new Rectangle(width * textureLocation.X, height * textureLocation.Y, width, height);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, frameWidth, frameHeight);
        }

        public void Update()
        {
            // no update needed
        }
    }
}
