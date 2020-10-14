using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    class ExplodingBombSprite : ISprite
    {
        private Texture2D sprite;
        public ExplodingBombSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue)
        {

        }
    }
}
