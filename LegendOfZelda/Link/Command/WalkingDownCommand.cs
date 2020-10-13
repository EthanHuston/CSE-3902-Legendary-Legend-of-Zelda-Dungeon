namespace LegendOfZelda.Link.Command
{
    class WalkingDownCommand : ICommand
    {
        private Game1 loz;
        public WalkingDownCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.MoveDown();
        }
    }
}
