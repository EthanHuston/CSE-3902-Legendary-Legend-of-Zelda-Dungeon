using LegendOfZelda.Interface;

namespace LegendOfZelda.Projectile
{
    public interface IProjectile : IDynamic
    {
        Constants.ProjectileOwner Owner { get; }
        double DamageAmount();
    }
}
