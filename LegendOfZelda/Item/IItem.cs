using LegendOfZelda.Interface;
using LegendOfZelda.Link;

namespace LegendOfZelda.Item
{
    interface IItem : ISpawnable
    {
        LinkConstants.ItemType GetItemType();
    }
}
