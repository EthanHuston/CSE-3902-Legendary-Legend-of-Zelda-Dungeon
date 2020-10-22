using LegendOfZelda.Interface;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    class ProjectileBlockDoNothingCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile projectile, IBlock block, Constants.Direction side)
        {
        }
    }
}
