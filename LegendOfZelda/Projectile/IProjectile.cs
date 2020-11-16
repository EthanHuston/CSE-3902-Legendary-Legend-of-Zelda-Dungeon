using LegendOfZelda.Interface;
using LegendOfZelda.Link;

namespace LegendOfZelda.Projectile
{
    internal interface IProjectile : IDynamic
    {
        Constants.ProjectileOwner Owner { get; }

        double DamageAmount();
        LinkConstants.ProjectileType GetProjectileType();
    }
}
