using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Link.Interface
{
    interface ILinkSprite : ISprite
    {
        bool FinishedAnimation();
    }
}
