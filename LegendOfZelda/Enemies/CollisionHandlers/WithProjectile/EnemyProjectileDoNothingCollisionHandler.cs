using LegendOfZelda.GameLogic;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    internal class EnemyProjectileDoNothingCollisionHandler : ICollisionHandler<INpc, IProjectile>
    {
        public void HandleCollision(INpc enemy, IProjectile bomb, Constants.Direction side)
        {
        }
    }
}
