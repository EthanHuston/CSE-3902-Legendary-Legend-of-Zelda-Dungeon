using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    class EnemyBombCollisionHandler : ICollisionHandler<INpc, IProjectile>
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
