namespace Sprint0.Link.Command
{
    class BowCommand : ICommand
    {
        private Game1 loz;
        public BowCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.PickUpBow();
        }
    }
}
