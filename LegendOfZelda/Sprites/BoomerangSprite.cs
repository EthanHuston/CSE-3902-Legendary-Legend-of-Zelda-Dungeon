using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda
{
    class BoomerangSprite : ISprite
    {
        private Texture2D sprite;
        public BoomerangSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            // No update needed for an unchanging object.
        }

        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue)
        {
            int width = (int)((float)sprite.Width / (float)3);
            Rectangle destinationRectangle = new Rectangle(XValue, YValue, 2 * width, 2 * sprite.Height);
            Rectangle sourceRectangle = new Rectangle(0, 0, width, sprite.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
