using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
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
