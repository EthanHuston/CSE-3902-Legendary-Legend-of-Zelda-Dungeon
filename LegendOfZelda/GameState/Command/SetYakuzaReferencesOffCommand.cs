using LegendOfZelda.GameState.OptionState;
using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    class SetYakuzaReferencesOffCommand : ICommand
    {
        private readonly IGameState gameState;

        public SetYakuzaReferencesOffCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            ((OptionGameState)gameState).UseYakuzaReferences = false;
        }
    }
}
