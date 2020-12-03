using System;
using System.Collections.Generic;
using LegendOfZelda.Interface;
using LegendOfZelda.Menu;

namespace LegendOfZelda.GameState.Command
{
    class SelectButtonCommand : ICommand
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
