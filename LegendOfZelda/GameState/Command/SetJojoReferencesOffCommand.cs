using LegendOfZelda.GameState.OptionState;
using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    class SetJojoReferencesOffCommand : ICommand
    {
        private readonly IGameState gameState;

        public SetJojoReferencesOffCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            ((OptionGameState)gameState).UseJojoReferences = false;
        }
    }
}
