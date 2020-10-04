namespace Sprint0.Link.Command
{
    class BombCommand : ICommand
    {
        private Game1 loz;
        public BombCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.UseBomb();
        }
    }
}
