using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    class SetJojoReferencesCommand : ICommand
    {
        private readonly IGameState gameState;

        public SetJojoReferencesCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            // i'm guessing we'll probably toggle a bool in option game state here?? might need to cast gameState to OptionGameState
        }
    }
}
