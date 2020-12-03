using LegendOfZelda.GameState.ItemSelectionState;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Menu;

namespace LegendOfZelda.GameState.Command
{
    internal class ChangeSecondaryToItem : ICommand
    {
        private readonly InventoryMenu menu;
        private readonly LinkConstants.ItemType item;

        public ChangeSecondaryToItem(IButtonMenu menu, LinkConstants.ItemType newSecondaryItem)
        {
            this.menu = (InventoryMenu)menu;
            item = newSecondaryItem;
        }

        public void Execute()
        {
            menu.UpdateSecondaryItem(item);
        }
    }
}
