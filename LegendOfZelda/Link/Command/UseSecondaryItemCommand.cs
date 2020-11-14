using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    class UseSecondaryItemCommand : ICommand
    {
        private readonly IPlayer link;

        public UseSecondaryItemCommand(IPlayer link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.UseSecondary();
        }
    }
}
