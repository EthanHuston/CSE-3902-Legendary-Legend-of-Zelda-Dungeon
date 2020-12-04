using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Command
{
    class SetOnePlayerCommand : ICommand
    {
        private readonly Game1 game;

        public SetOnePlayerCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.NumPlayers = 1;
        }
    }
}
