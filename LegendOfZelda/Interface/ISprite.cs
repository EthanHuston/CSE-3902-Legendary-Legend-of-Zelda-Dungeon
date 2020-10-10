using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Interface
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, int XValue, int YValue);
    }
}
