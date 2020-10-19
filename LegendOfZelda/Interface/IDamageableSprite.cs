using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Interface
{
    interface IDamageableSprite : IItemSprite
    {
        void Draw(SpriteBatch spriteBatch, Point position, bool damaged);
    }
}
