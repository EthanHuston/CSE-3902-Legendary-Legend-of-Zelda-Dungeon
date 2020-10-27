using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Interface
{
    internal interface ILinkSprite : IDamageableSprite
    {
        void Draw(SpriteBatch spriteBatch, Point position, bool damaged, bool walkingToggle);
        bool FinishedAnimation();
    }
}
