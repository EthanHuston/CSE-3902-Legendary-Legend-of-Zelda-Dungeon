using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class MoveLeftCommand : ICommand
    {
        private readonly IPlayer link;
        public MoveLeftCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.MoveLeft();
        }
    }
}
