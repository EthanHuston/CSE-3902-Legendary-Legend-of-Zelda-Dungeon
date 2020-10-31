using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    internal class BoomerangBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile boomerang, IBlock block, Constants.Direction side)
        {
            if (block.GetType() == typeof(TileWater)) return;
            BoomerangFlyingProjectile boomerangCast = (BoomerangFlyingProjectile)boomerang;
            boomerangCast.ReturnToOwner();
        }
    }
}
