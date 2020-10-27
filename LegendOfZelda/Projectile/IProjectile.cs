using LegendOfZelda.Interface;

namespace LegendOfZelda.Projectile
{
    public interface IProjectile : IDynamic
    {
        Constants.ItemOwner Owner { get; }
        double DamageAmount();
    }
}
