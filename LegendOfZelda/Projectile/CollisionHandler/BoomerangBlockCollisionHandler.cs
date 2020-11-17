using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using System;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    internal class BoomerangBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile boomerang, IBlock block, Constants.Direction side)
        {
            Type blockType = block.GetType();
            if (blockType == typeof(TileWater) || blockType == typeof(SecretRoomWall)) return;
            BoomerangFlyingProjectile boomerangCast = (BoomerangFlyingProjectile)boomerang;
            boomerangCast.ReturnToOwner();
        }
    }
}
