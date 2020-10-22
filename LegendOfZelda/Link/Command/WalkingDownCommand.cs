using LegendOfZelda.Interface;
namespace LegendOfZelda.Link.Command
{
    class WalkingDownCommand : ICommand
    {
        private IPlayer link;
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
