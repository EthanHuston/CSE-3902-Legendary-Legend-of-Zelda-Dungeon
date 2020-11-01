using LegendOfZelda.Interface;
using LegendOfZelda.Link;

namespace LegendOfZelda.Item
{
    internal interface IItem : ISpawnable
    {
        LinkConstants.ItemType GetItemType();
    }
}
