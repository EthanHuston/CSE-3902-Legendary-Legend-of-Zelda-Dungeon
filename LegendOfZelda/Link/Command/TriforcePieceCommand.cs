namespace Sprint0.Link.Command
{
    class TriforcePieceCommand : ICommand
    {
        private Game1 loz;
        public TriforcePieceCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.PickUpTriforce();
        }
    }
}
