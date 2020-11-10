using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    class ItemSelectCommand : ICommand
    {
        private IGameState gameState;

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
