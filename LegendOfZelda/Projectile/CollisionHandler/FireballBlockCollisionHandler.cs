using LegendOfZelda.Interface;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    class FireballBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile fireball, IBlock block, Constants.Direction side)
        {
            fireball.Despawn();
        }
    }
}
