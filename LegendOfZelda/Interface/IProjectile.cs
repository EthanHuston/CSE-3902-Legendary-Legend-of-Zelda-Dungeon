namespace LegendOfZelda.Interface
{
    public interface IProjectile : IDynamic
    {
        Constants.ItemOwner GetItemOwner();
        double DamageAmount();
    }
}
