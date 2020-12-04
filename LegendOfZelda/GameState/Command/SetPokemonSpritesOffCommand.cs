using LegendOfZelda.GameState.OptionState;
using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    class SetPokemonSpritesOffCommand : ICommand
    {
        private readonly IGameState gameState;

        public SetPokemonSpritesOffCommand(IGameState gameState)
        {
            this.gameState = gameState;
        }

        public void Execute()
        {
            ((OptionGameState)gameState).UsePokemonSprites = false;
        }
    }
}
