namespace LegendOfZelda.Link.Command
{
    class PickUpTriforcePieceCommand : ICommand
    {
        private Game1 loz;
        public PickUpTriforcePieceCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.PickUpTriforce();
        }
    }
}
