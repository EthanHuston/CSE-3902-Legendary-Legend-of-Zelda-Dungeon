using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    internal class PauseGameCommand : ICommand
    {
        private readonly IGameState gameState;

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
