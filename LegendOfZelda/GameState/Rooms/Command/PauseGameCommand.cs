using LegendOfZelda.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.GameState.Rooms.Command
{
    class PauseGameCommand : ICommand
    {
        private IGameState gameState;

        public PauseGameCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            gameState.SwitchToPauseState();
        }
    }
}
