using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    class UsePrimaryItemCommand : ICommand
    {
        private readonly IPlayer link;

        public UsePrimaryItemCommand(IPlayer link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.UsePrimary();
        }
    }
}
