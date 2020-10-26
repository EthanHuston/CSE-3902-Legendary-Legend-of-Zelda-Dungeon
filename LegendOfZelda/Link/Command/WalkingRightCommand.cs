using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    class WalkingRightCommand : ICommand
    {
        private IPlayer link;
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
