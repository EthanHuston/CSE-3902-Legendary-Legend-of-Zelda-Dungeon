namespace LegendOfZelda.Interface
{
    public interface IProjectile : IDynamic
    {
        Constants.ItemOwner Owner { get; }
        double DamageAmount();
    }
}
