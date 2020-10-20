using LegendOfZelda.Interface;
namespace LegendOfZelda.Link.Command
{
    class PickUpBowCommand : ICommand
    {
        private IPlayer link;
        public PickUpBowCommand(IPlayer player)
        {
            link = player;
        }
        public void Execute()
        {
            link.PickUpBow();
        }
    }
}
