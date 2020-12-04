using Microsoft.Xna.Framework;

namespace LegendOfZelda.Menu
{
    internal interface IOnOffButton : IButton
    {
        bool IsOn { get; set; }
    }
}
