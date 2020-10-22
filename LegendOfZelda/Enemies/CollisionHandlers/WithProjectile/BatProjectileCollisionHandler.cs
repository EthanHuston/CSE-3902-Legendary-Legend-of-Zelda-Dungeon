using LegendOfZelda.Interface;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    class BatProjectileCollisionHandler : ICollisionHandler<INpc, IProjectile>
    {
        public void HandleCollision(INpc enemy, IProjectile projectile, Constants.Direction side)
        {
            enemy.TakeDamage(projectile.DamageAmount());

        }
    }
}
