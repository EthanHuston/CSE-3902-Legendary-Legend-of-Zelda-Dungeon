using LegendOfZelda.GameLogic;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    internal class EnemyBombCollisionHandler : ICollisionHandler<INpc, IProjectile>
    {
        public void HandleCollision(INpc enemy, IProjectile bomb, Constants.Direction side)
        {
            BombExplodingProjectile bombCast = (BombExplodingProjectile)bomb;
            if (bombCast.IsExploded())
            {
                enemy.TakeDamage(bombCast.DamageAmount());
            }
        }
    }
}
