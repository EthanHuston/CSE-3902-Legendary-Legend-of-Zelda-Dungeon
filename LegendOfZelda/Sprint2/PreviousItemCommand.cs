using LegendOfZelda.Interface;
namespace LegendOfZelda.Sprint2

{
    class PreviousItemCommand : ICommand
    {
        private Game1 myGame;
        public PreviousItemCommand(Game1 game1)
        {
            myGame = game1;
        }
        public void Execute()
        {
            myGame.sprint2.PreviousItem();
        }
    }
}
