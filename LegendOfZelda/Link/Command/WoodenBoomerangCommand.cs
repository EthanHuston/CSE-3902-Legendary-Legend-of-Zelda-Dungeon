namespace Sprint0.Link.Command
{
    class WoodenBoomerangCommand : ICommand
    {
        private Game1 loz;
        public WoodenBoomerangCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.UseBoomerang();
        }
    }
}
