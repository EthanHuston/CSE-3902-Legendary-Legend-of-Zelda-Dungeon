using LegendOfZelda.GameState.OptionState;
using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    class SetJojoReferencesOnCommand : ICommand
    {
        private readonly IGameState gameState;

        public SetJojoReferencesOnCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            ((OptionGameState)gameState).UseJojoReferences = true;
        }
    }
}
