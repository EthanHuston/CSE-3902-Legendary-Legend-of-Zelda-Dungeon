using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    class UseBowCommand : ICommand
    {
        private IPlayer link;
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
