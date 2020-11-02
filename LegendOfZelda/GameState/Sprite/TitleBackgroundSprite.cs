using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.Sprite
{
    class TitleBackgroundSprite : ITextureAtlasSprite
    {
        private readonly Texture2D sprite;
        private const int numRows = 1;
        private const int numColumns = 3;
        private readonly int frameWidth;
        private readonly int frameHeight;

        public TitleBackgroundSprite(Texture2D sprite)
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
            
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, frameWidth, frameHeight);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(RoomConstants.SpriteMultiplier * frameWidth), (int)(RoomConstants.SpriteMultiplier * frameHeight));
            Rectangle sourceRectangle = new Rectangle(textureLocation.X, textureLocation.Y, frameWidth, frameHeight);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
