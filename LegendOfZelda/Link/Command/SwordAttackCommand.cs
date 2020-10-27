using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    class SwordAttackCommand : ICommand
    {
        private IPlayer link;
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
