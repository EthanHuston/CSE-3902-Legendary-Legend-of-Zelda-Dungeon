using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    class PickUpHeartContainerCommand : ICommand
    {
        private IPlayer link;
        public PickUpHeartContainerCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.PickUpHeartContainer();
        }
    }
}
