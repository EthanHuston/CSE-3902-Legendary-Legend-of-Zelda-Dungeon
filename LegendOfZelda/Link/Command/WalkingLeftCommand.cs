using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    class WalkingLeftCommand : ICommand
    {
        private IPlayer link;
        public WalkingLeftCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.MoveLeft();
        }
    }
}
