using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class UseSecondaryItem : ICommand
    {
        private readonly IPlayer link;

        public UseSecondaryItem(IPlayer link)
        {
            this.link = link;
        }

        public void Execute()
        {
            link.UseSecondary();
        }
    }
}
