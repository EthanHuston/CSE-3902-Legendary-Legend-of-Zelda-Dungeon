namespace LegendOfZelda.Sprint2
{
    class PreviousBlockCommand : ICommand
    {
        private Game1 myGame;
        public PreviousBlockCommand(Game1 game1)
        {
            myGame = game1;
        }
        public void Execute()
        {
            myGame.sprint2.PreviousBlock();
        }
    }
}
