using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    class StopMovingCommand : ICommand
    {
        private readonly IPlayer link;

        public StopMovingCommand(IPlayer link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.StopMoving();
        }
    }
}
