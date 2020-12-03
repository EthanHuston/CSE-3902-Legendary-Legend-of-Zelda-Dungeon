using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    internal class ItemSelectCommand : ICommand
    {
        private readonly IGameState gameState;
        private readonly int playerNum;

        public ItemSelectCommand(IGameState gameState, int playerNum)
        {
            this.gameState = gameState;
            this.playerNum = playerNum;
        }

        public void Execute()
        {
            gameState.SwitchToItemSelectionState(playerNum);
        }
    }
}
