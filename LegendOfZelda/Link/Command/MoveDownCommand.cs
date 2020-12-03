using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class MoveDownCommand : ICommand
    {
        private readonly IPlayer link;
        public MoveDownCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.MoveDown();
        }
    }
}
