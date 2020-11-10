using LegendOfZelda.Interface;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.Command
{
    class ChangeSecondaryToItem : ICommand
    {
        private readonly IPlayer link;
        private readonly LinkConstants.ItemType item;

        public ChangeSecondaryToItem(IPlayer link, LinkConstants.ItemType newSecondaryItem)
        {
            this.link = link;
            item = newSecondaryItem;
        }

        public void Execute()
        {
            link.SecondaryItem = item;
        }
    }
}
