using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    internal class StartGameCommand : ICommand
    {
        private readonly IGameState gameState;
        public StartGameCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            gameState.SwitchToRoomState();
        }
    }
}
