
using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class PickUpBoomerangCommand : ICommand
    {
        private readonly IPlayer link;
        public PickUpBoomerangCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.PickUpBoomerang();
        }
    }
}
