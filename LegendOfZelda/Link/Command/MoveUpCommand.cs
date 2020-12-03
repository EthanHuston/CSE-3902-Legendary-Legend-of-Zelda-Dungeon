using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class MoveUpCommand : ICommand
    {
        private readonly IPlayer link;
        public MoveUpCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.MoveUp();
        }
    }
}
