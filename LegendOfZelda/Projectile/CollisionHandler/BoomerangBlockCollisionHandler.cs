using LegendOfZelda.Interface;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    class BoomerangBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile boomerang, IBlock block, Constants.Direction side)
        {
            BoomerangFlyingProjectile boomerangCast = (BoomerangFlyingProjectile)boomerang;
            boomerangCast.ReturnToOwner();
        }
    }
}
