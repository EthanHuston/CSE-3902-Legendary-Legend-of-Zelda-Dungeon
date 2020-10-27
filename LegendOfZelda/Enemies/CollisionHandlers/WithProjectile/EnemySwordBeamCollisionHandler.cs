using LegendOfZelda.GameLogic;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    internal class EnemySwordBeamCollisionHandler : ICollisionHandler<INpc, IProjectile>
    {
        public void HandleCollision(INpc enemy, IProjectile swordBeam, Constants.Direction side)
        {
            SwordBeamFlyingProjectile swordBeamCast = (SwordBeamFlyingProjectile)swordBeam;
            enemy.TakeDamage(swordBeamCast.DamageAmount());
            swordBeamCast.ExplodeSword();
        }
    }
}
