using LegendOfZelda.Interface;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    class EnemySwordBeamCollisionHandler : ICollisionHandler<INpc, IProjectile>
    {
        public void HandleCollision(INpc enemy, IProjectile swordBeam, Constants.Direction side)
        {
            SwordBeamFlyingProjectile swordBeamCast = (SwordBeamFlyingProjectile)swordBeam;
            enemy.TakeDamage(swordBeamCast.DamageAmount());
            swordBeamCast.ExplodeSword();
        }
    }
}
