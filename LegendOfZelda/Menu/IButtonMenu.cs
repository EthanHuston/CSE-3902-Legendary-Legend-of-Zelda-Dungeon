﻿using System.Collections.Generic;

namespace LegendOfZelda.Menu
{
    internal interface IButtonMenu : IMenu
    {
        List<IButton> Buttons { get; }
        void MoveSelection(Constants.Direction direction);
        IButton SelectedButton { get; }
    }
}
