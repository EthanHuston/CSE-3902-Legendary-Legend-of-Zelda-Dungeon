using LegendOfZelda.Interface;
using LegendOfZelda.Menu;
using System;

namespace LegendOfZelda.GameState.Command
{
    internal class ToggleButtonCommand : ICommand
    {
        private readonly IButtonMenu menu;
        private readonly Type buttonType;

        public ToggleButtonCommand(IButtonMenu menu, Type buttonType)
        {
            this.menu = menu;
            this.buttonType = buttonType;
        }

        public void Execute()
        {
            menu.ToggleButton(buttonType);
        }
    }
}
