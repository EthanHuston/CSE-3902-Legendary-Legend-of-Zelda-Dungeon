
using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    class PickUpBoomerangCommand : ICommand
    {
        private IPlayer link;
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
