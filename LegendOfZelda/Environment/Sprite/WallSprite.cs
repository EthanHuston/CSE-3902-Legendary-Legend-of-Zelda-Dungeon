using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment.Sprite
{
    internal class WallSprite : ITextureAtlasSprite
    {
        private readonly Texture2D sprite;

        public WallSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Draw(spriteBatch, position, Point.Zero, layer);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation, float layer)
        {
            int width = sprite.Width;
            int height = sprite.Height / 4;
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(RoomConstants.SpriteMultiplier * width), (int)(RoomConstants.SpriteMultiplier * height));
            Rectangle sourceRectangle = new Rectangle(width * textureLocation.X, height * textureLocation.Y, width, height);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Rectangle textureSource, float layer)
        {
            Draw(spriteBatch, position, new Point(textureSource.X, textureSource.Y), layer);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int) (sprite.Width * Constants.GameScaler), (int) (sprite.Height * Constants.GameScaler));
        }

        public void Update()
        {
            //No Update Required
        }
    }
}
