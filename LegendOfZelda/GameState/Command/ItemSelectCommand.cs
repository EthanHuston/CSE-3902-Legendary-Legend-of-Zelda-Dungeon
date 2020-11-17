using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    internal class ItemSelectCommand : ICommand
    {
        private readonly IGameState gameState;

        public ItemSelectCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            gameState.SwitchToItemSelectionState();
        }
    }
}
