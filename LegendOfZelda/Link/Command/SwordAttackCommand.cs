namespace Sprint0.Link.Command
{
    class SwordAttackCommand : ICommand
    {
        private Game1 loz;
        public SwordAttackCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.UseSword();
        }
    }
}
