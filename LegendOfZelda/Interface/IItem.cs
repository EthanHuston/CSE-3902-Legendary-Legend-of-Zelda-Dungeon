namespace LegendOfZelda.Interface
{
    public interface IItem : IDynamic
    {
        Constants.ItemOwner GetItemOwner();
    }
}
