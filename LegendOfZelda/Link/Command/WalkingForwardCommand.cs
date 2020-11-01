using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class WalkingForwardCommand : ICommand
    {
        private readonly IPlayer link;
        public WalkingForwardCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.MoveUp();
        }
    }
}
