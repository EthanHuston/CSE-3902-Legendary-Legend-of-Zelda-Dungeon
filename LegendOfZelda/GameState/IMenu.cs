using LegendOfZelda.GameState.Button;
using LegendOfZelda.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.GameState
{
    interface IMenu : ISpawnable
    {
        List<IButton> Buttons { get; }
    }
}
