using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, int XValue, int YValue);
    }
}
