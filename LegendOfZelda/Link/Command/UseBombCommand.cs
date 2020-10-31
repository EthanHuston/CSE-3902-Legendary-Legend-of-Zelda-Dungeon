using LegendOfZelda.Interface;

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
