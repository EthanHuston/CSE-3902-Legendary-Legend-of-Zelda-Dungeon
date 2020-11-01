using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class WalkingRightCommand : ICommand
    {
        private readonly IPlayer link;
        public WalkingRightCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.MoveRight();
        }
    }
}
