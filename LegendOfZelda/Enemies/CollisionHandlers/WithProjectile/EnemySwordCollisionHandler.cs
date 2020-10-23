using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    class EnemySwordCollisionHandler : ICollisionHandler<INpc, IProjectile>
    {
        public void HandleCollision(INpc enemy, IProjectile sword, Constants.Direction side)
        {
            enemy.TakeDamage(sword.DamageAmount());
        }
    }
}
