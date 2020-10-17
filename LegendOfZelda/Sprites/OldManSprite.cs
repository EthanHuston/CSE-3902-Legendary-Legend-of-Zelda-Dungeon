using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class OldManSprite : IDamageableSprite
    {
        private Texture2D sprite;
        public OldManSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            Rectangle destinationRectangle = new Rectangle(XValue, YValue, 2 * sprite.Width, 2 * sprite.Width);
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
