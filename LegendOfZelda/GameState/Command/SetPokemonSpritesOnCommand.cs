using LegendOfZelda.GameState.OptionState;
using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    class SetPokemonSpritesOnCommand : ICommand
    {
        private readonly IGameState gameState;

        public SetPokemonSpritesOnCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            ((OptionGameState)gameState).UsePokemonSprites = true;
        }
    }
}
