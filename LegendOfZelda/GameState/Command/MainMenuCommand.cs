using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    internal class MainMenuCommand : ICommand
    {
        private readonly IGameState gameState;

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
