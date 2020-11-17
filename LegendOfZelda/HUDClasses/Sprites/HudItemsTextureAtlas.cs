using LegendOfZelda.Interface;
using LegendOfZelda.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses.Sprite
{
    internal class HUDItemsTextureAtlas : ITextureAtlasSprite
    {
        private readonly Texture2D sprite;

        public HUDItemsTextureAtlas(Texture2D sprite)
        {
            this.sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Rectangle textureSource, float layer)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(textureSource.Width * Constants.GameScaler), (int)(textureSource.Height * Constants.GameScaler));
            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, textureSource, Color.White, layer);
        }

        public void Draw(SpriteBatch spriteBatch, Point position, Point textureLocation, float layer)
        {
            //Not needed
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            //Not needed
        }

        public Rectangle GetPositionRectangle()
        {
            return Rectangle.Empty;
        }

        public void Update()
        {
            //No update needed
        }
    }
}
