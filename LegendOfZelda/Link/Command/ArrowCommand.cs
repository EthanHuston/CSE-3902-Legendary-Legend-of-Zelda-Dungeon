namespace LegendOfZelda.Link.Command
{
    class ArrowCommand : ICommand
    {
        private Game1 loz;
        public ArrowCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.UseBow();
        }
    }
}
