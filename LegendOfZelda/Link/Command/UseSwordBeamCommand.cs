namespace LegendOfZelda.Link.Command
{
    class UseSwordBeamCommand : ICommand
    {
        private Game1 loz;
        public UseSwordBeamCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.UseSwordBeam();
        }
    }
}
