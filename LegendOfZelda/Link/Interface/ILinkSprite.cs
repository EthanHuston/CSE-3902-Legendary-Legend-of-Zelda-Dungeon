using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Interface
{
    internal interface ILinkSprite : IDamageableSprite
    {
        bool FinishedAnimation();
    }
}
