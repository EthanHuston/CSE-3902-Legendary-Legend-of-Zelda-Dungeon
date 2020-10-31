using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class SwordAttackCommand : ICommand
    {
        private readonly IPlayer link;
        public SwordAttackCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.UseSword();
        }
    }
}
