using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Interface
{
    internal interface IDamageableSprite : ISprite
    {
        void Draw(SpriteBatch spriteBatch, Point position, bool damaged, float layer);
    }
}
