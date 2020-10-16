using LegendOfZelda.Interface;
namespace LegendOfZelda.Sprint2
{
    class PreviousEnemyCommand : ICommand
    {
        private Game1 myGame;
        public PreviousEnemyCommand(Game1 game1)
        {
            myGame = game1;
        }
        public void Execute()
        {
            myGame.sprint2.PreviousEnemy();
        }
    }
}
