using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    internal class OptionCommand : ICommand
    {
        private readonly IGameState gameState;

        public OptionCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            gameState.SwitchToOptionState();
        }
    }
}
