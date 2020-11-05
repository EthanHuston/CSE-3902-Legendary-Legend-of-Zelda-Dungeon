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
            Draw(spriteBatch, position, Point.Zero);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(frameWidth * Constants.GameScaler), (int)(frameHeight * Constants.GameScaler));
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation)
        {
            Rectangle sourceRectangle = new Rectangle(textureLocation.X, textureLocation.Y, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(RoomConstants.SpriteMultiplier * frameWidth), (int)(RoomConstants.SpriteMultiplier * frameHeight));
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
