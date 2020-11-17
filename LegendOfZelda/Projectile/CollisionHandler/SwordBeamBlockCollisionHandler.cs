using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using System;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    internal class SwordBeamBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile swordBeam, IBlock block, Constants.Direction side)
        {
            Type blockType = block.GetType();
            if (blockType == typeof(TileWater) || blockType == typeof(SecretRoomWall)) return;
            SwordBeamFlyingProjectile swordBeamCast = (SwordBeamFlyingProjectile)swordBeam;
            swordBeamCast.ExplodeSword();
        }
    }
}
