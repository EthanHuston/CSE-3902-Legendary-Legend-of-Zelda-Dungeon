namespace LegendOfZelda.Link.Command
{
    class DamageLinkCommand : ICommand
    {
        private Game1 loz;
        public DamageLinkCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.TakeDamage(10); // Arbitrary number for the purposes of Sprint 2.
        }
    }
}
