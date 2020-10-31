using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class UseBowCommand : ICommand
    {
        private readonly IPlayer link;
        public UseBowCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.UseBow();
        }
    }
}
