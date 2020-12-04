using LegendOfZelda.GameState.OptionState;
using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    class SetYakuzaReferencesOnCommand : ICommand
    {
        private readonly IGameState gameState;

        public SetYakuzaReferencesOnCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            ((OptionGameState)gameState).UseYakuzaReferences = true;
        }
    }
}
