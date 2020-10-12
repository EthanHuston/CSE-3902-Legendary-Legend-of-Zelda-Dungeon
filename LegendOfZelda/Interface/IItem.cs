namespace LegendOfZelda.Interface
{
    interface IItem : IDynamic
    {
        Constants.ItemOwner GetItemOwner();
    }
}
