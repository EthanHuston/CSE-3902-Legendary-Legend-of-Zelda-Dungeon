using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment.Sprite
{
    internal class WallSprite : ITextureAtlasSprite
    {
        private readonly Texture2D sprite;
        private const int numRows = 4;
        private const int numColumns = 1;
        private readonly int width;
        private readonly int height;

        public WallSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            width = sprite.Width / numColumns;
            height = sprite.Height / numRows;
        }
        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Draw(spriteBatch, position, Point.Zero, layer);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation, float layer)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(RoomConstants.SpriteMultiplier * width), (int)(RoomConstants.SpriteMultiplier * height));
            Rectangle sourceRectangle = new Rectangle(width * textureLocation.X, height * textureLocation.Y, width, height);
            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Rectangle textureSource, float layer)
        {
            Draw(spriteBatch, position, new Point(textureSource.X, textureSource.Y), layer);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int) (width * Constants.GameScaler), (int) (height * Constants.GameScaler));
        }

        public void Update()
        {
            //No Update Required
        }
    }
}
