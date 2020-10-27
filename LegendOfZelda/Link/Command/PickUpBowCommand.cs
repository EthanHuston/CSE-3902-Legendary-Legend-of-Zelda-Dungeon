using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class PickUpBowCommand : ICommand
    {
        private readonly IPlayer link;
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
