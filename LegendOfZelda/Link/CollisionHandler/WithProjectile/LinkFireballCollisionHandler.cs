using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    class LinkFireballCollisionHandler : ICollisionHandler<IPlayer, IProjectile>
    {
        public void HandleCollision(IPlayer link, IProjectile fireball, Constants.Direction side)
        {
            link.BeDamaged(fireball.DamageAmount());
            fireball.Despawn();
        }
    }
}
