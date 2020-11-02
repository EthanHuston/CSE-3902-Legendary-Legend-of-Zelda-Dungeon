using LegendOfZelda.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.GameState.Pause.Command
{
    class MainMenuCommand : ICommand
    {
        private IGameState gameState;

        public MainMenuCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            gameState.SwitchToMainMenuState();
        }
    }
}
