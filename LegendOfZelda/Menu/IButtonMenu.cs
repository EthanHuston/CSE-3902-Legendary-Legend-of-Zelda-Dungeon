using System;
using System.Collections.Generic;

namespace LegendOfZelda.Menu
{
    internal interface IButtonMenu : IMenu
    {
        ButtonSelector ButtonSelector { get; }
        List<IButton> Buttons { get; }
        void MoveSelection(Constants.Direction direction);
        void ToggleButton(Type buttonType);
    }
}
