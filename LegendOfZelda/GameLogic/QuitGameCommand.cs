using LegendOfZelda.Interface;

namespace LegendOfZelda.GameLogic
{
    internal class QuitGameCommand : ICommand
    {
        private readonly Game1 myGame;
        public QuitGameCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }
    }
}
