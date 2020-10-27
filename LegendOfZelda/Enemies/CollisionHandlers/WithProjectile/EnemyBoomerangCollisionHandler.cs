using LegendOfZelda.GameLogic;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    internal class EnemyBoomerangCollisionHandler : ICollisionHandler<INpc, IProjectile>
    {
        public void HandleCollision(INpc enemy, IProjectile boomerang, Constants.Direction side)
        {
            if (boomerang.Owner == Constants.ItemOwner.Link)
            {
                BoomerangFlyingProjectile boomerangCast = (BoomerangFlyingProjectile)boomerang;
                enemy.TakeDamage(boomerangCast.DamageAmount());
                boomerangCast.ReturnToOwner();
            }
        }
    }
}
