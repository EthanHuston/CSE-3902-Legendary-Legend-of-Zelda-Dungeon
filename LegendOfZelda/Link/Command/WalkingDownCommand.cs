using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class WalkingDownCommand : ICommand
    {
        private readonly IPlayer link;
        public WalkingDownCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.MoveDown();
        }
    }
}
