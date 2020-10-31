using LegendOfZelda.GameLogic;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    internal class EnemyArrowCollisionHandler : ICollisionHandler<INpc, IProjectile>
    {
        public void HandleCollision(INpc enemy, IProjectile arrow, Constants.Direction side)
        {
            enemy.TakeDamage(arrow.DamageAmount());
            arrow.Despawn();
        }
    }
}
