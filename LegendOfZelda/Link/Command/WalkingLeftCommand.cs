using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class WalkingLeftCommand : ICommand
    {
        private readonly IPlayer link;
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
