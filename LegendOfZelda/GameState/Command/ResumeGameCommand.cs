using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    class ResumeGameCommand : ICommand
    {
        private readonly IGameState gameState;

        public ResumeGameCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            gameState.SwitchToRoomState();
        }
    }
}
