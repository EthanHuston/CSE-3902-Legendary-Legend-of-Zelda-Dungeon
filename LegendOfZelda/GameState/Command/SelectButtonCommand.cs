using LegendOfZelda.Interface;
using LegendOfZelda.Menu;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Command
{
    internal class SelectButtonCommand : ICommand
    {
        private readonly ButtonSelector buttonSelector;
        private readonly Dictionary<Type, ICommand> buttonCommands;

        public SelectButtonCommand(ButtonSelector buttonSelector, Dictionary<Type, ICommand> buttonCommands)
        {
            this.buttonSelector = buttonSelector;
            this.buttonCommands = buttonCommands;
        }

        public void Execute()
        {
            buttonCommands[buttonSelector.ButtonSelected.GetType()].Execute();
        }
    }
}
