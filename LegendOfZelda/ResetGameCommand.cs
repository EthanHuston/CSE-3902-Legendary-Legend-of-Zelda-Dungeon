namespace LegendOfZelda
{
    internal class ResetGameCommand : ICommand
    {
        private Game1 game1;

        public ResetGameCommand(Game1 game1)
        {
            this.game1 = game1;
        }

        public void Execute()
        {
            this.game1.ResetGame();
        }
    }
}