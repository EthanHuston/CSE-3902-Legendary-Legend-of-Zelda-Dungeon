using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.GameState.Sprite
{
    internal class GameStateTextureAtlasSprite : ITextureAtlasSprite
    {
        private readonly Texture2D sprite;

        public GameStateTextureAtlasSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Update()
        {
            // No update needed for an unchanging object.
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            Draw(spriteBatch, position, Rectangle.Empty, layer);
        }

        public Rectangle GetPositionRectangle()
        {
            return Rectangle.Empty;
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Rectangle textureSource, float layer)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(RoomConstants.SpriteMultiplier * textureSource.Width), (int)(RoomConstants.SpriteMultiplier * textureSource.Height));
            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, textureSource, Color.White, layer);
        }
        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation, float layer)
        {
            Draw(spriteBatch, position, Rectangle.Empty, layer);
        }
    }
}
