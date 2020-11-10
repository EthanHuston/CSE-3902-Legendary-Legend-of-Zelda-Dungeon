using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class UsePrimaryItem : ICommand
    {
        private readonly IPlayer link;

        public UsePrimaryItem(IPlayer link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.UsePrimary();
        }
    }
}
