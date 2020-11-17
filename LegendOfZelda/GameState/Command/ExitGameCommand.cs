using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    internal class ExitGameCommand : ICommand
    {
        private readonly IGameState gameState;

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
