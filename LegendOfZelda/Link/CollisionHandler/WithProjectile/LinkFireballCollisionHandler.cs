using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    internal class LinkFireballCollisionHandler : ICollisionHandler<IPlayer, IProjectile>
    {
        public void HandleCollision(IPlayer link, IProjectile fireball, Constants.Direction side)
        {
            link.BeDamaged(fireball.DamageAmount());
            fireball.SafeToDespawn = true;
        }
    }
}
