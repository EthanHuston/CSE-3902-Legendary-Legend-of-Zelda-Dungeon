using System.Collections.Generic;

namespace LegendOfZelda.Menu
{
    internal interface IButtonMenu : IMenu
    {
        List<IButton> Buttons { get; }
    }
}
