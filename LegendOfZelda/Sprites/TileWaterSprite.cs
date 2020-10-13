using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class TileWaterSprite : ISprite
    {
        private Texture2D sprite;
        public TileWaterSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            // No update needed for an unchanging object.
        }

        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue)
        {
            Rectangle destinationRectangle = new Rectangle(XValue, YValue, sprite.Width, sprite.Height);
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
