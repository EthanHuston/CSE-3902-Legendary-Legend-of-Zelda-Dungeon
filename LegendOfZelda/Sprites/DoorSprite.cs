using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class DoorSprite : ISprite
    {
        private Texture2D sprite;
        public DoorSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue)
        {
        }

        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue, int row, int column)
        {
            int width = sprite.Width / 4;
            int height = sprite.Height / 4;
            Rectangle destinationRectangle = new Rectangle(XValue, YValue, width, height);
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public void Update()
        {

        }
    }
}
