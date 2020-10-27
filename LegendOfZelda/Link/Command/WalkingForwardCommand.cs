using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    class WalkingForwardCommand : ICommand
    {
        private IPlayer link;
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
