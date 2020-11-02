using LegendOfZelda.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.GameState.Pause.Command
{
    class ExitGameCommand : ICommand
    {
        private IGameState gameState;

        public ExitGameCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            gameState.Game.Exit();
        }
    }
}
