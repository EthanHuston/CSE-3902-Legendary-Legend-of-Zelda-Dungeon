namespace LegendOfZelda.Link.Command
{
    class UseBombCommand : ICommand
    {
        private Game1 loz;
        public UseBombCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.UseBomb();
        }
    }
}
