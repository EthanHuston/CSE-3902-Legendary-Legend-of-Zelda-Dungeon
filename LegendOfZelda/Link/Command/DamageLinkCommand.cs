using LegendOfZelda.Interface;
namespace LegendOfZelda.Link.Command
{
    class DamageLinkCommand : ICommand
    {
        private IPlayer link;
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
