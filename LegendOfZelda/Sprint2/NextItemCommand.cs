namespace LegendOfZelda.Sprint2
{
    class NextItemCommand : ICommand
    {
        private Game1 myGame;
        public NextItemCommand(Game1 game1)
        {
            myGame = game1;
        }
        public void Execute()
        {
            myGame.sprint2.NextItem();
        }
    }
}
