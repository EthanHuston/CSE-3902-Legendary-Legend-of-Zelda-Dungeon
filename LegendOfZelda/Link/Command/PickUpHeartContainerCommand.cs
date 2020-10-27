using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class PickUpHeartContainerCommand : ICommand
    {
        private readonly IPlayer link;
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
