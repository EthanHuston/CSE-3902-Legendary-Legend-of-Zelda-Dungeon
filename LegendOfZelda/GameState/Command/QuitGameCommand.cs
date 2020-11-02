using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    internal class QuitGameCommand : ICommand
    {
        private readonly IGameState gameState;
        public QuitGameCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            gameState.Game.Exit();
        }
    }
}
