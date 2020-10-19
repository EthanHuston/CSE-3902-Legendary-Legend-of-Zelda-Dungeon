using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Interface
{
    interface ILinkSprite : IDamageableSprite
    {
        bool FinishedAnimation();
    }
}
