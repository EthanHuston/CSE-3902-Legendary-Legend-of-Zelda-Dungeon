using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    class SetTwoPlayerCommand : ICommand
    {
        private readonly Game1 game;

        public SetTwoPlayerCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.NumPlayers = 2;
        }
    }
}
