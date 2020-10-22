using LegendOfZelda.Interface;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    class EnemyArrowCollisionHandler : ICollisionHandler<INpc, IProjectile>
    {
        public void HandleCollision(INpc enemy, IProjectile arrow, Constants.Direction side)
        {
            enemy.TakeDamage(arrow.DamageAmount());
            arrow.Despawn();
        }
    }
}
