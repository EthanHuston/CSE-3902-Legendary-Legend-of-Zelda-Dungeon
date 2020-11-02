using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
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
