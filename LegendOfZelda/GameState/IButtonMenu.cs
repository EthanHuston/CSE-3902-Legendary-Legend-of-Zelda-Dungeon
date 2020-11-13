using LegendOfZelda.GameState.Button;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState
{
    interface IButtonMenu : IMenu
    {
        List<IButton> Buttons { get; }
    }
}
