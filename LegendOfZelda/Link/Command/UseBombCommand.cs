using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class UseBombCommand : ICommand
    {
        private readonly IPlayer link;
        public UseBombCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.UseBomb();
        }
    }
}
