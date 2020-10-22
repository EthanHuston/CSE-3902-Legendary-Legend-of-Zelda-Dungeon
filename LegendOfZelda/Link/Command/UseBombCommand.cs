using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    class UseBombCommand : ICommand
    {
        private IPlayer link;
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
