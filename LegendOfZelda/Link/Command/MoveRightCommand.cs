using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class MoveRightCommand : ICommand
    {
        private readonly IPlayer link;
        public MoveRightCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.MoveRight();
        }
    }
}
