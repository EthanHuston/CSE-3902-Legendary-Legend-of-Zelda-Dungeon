using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.Sprite
{
    class GameStateTextureAtlasSprite : ITextureAtlasSprite
    {
        private readonly Texture2D sprite;
        private const int numRows = 1;
        private const int numColumns = 3;
        private readonly int frameWidth;
        private readonly int frameHeight;

        public GameStateTextureAtlasSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;
        }

        public void Update()
        {
            // No update needed for an unchanging object.
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Draw(spriteBatch, position, Rectangle.Empty);
        }

        public Rectangle GetPositionRectangle()
        {
            return Rectangle.Empty;
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Rectangle textureSource)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(RoomConstants.SpriteMultiplier * textureSource.Width), (int)(RoomConstants.SpriteMultiplier * textureSource.Height));
            spriteBatch.Draw(sprite, destinationRectangle, textureSource, Color.White);
        }
        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation)
        {
            Draw(spriteBatch, position, Rectangle.Empty);
        }
    }
}
