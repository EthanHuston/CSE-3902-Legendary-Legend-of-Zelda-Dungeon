namespace Sprint0.Link.Command
{
    class SwordBeamCommand : ICommand
    {
        private Game1 loz;
        public SwordBeamCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.UseSwordBeam();
        }
    }
}
