using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    internal class BoomerangBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile boomerang, IBlock block, Constants.Direction side)
        {
            BoomerangFlyingProjectile boomerangCast = (BoomerangFlyingProjectile)boomerang;
            boomerangCast.ReturnToOwner();
        }
    }
}
