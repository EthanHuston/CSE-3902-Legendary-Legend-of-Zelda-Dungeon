using LegendOfZelda.GameState.Button;
using System.Collections.Generic;

namespace LegendOfZelda.GameState
{
    internal interface IButtonMenu : IMenu
    {
        List<IButton> Buttons { get; }
    }
}
