using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithProjectile
{
    class LinkBoomerangCollisionHandler : ICollisionHandler<IPlayer, IProjectile>
    {
        public void HandleCollision(IPlayer link, IProjectile boomerang, Constants.Direction side)
        {
            BoomerangFlyingProjectile boomerangCast = (BoomerangFlyingProjectile)boomerang;
            if (boomerang.Owner == Constants.ProjectileOwner.Link) return;
            link.BeDamaged(boomerang.DamageAmount());
            boomerangCast.ReturnToOwner();
        }
    }
}
