using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class DamageLinkCommand : ICommand
    {
        private readonly IPlayer link;
        public DamageLinkCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.BeDamaged(10); // Arbitrary number for the purposes of Sprint 2.
        }
    }
}
