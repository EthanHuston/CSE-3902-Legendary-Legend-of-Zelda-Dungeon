using LegendOfZelda.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Button
{
    interface IMenu : ISpawnable
    {
        List<IButton> Buttons { get; }
    }
}
