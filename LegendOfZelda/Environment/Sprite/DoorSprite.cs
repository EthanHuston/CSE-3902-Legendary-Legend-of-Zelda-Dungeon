using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment.Sprite
{
    internal class DoorSprite : ITextureAtlasSprite
    {
        private readonly Texture2D sprite;
        private readonly int frameWidth;
        private readonly int frameHeight;
        private const int numRows = 4;
        private const int numColumns = 7;

        public DoorSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;
        }
        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Draw(spriteBatch, position, Point.Zero, layer);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation, float layer)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * frameWidth), (int)(Constants.GameScaler * frameHeight));
            Rectangle sourceRectangle = new Rectangle(frameWidth * textureLocation.X, frameHeight * textureLocation.Y, frameWidth, frameHeight);
            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));
        }

        public void Update()
        {
            // no update needed
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Rectangle textureSource, float layer)
        {
            Draw(spriteBatch, position, new Point(textureSource.X, textureSource.Y), layer);
        }
    }
}
