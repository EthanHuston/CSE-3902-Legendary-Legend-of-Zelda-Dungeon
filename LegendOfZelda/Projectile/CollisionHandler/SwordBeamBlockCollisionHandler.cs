using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    internal class SwordBeamBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile swordBeam, IBlock block, Constants.Direction side)
        {
            SwordBeamFlyingProjectile swordBeamCast = (SwordBeamFlyingProjectile)swordBeam;
            swordBeamCast.ExplodeSword();
        }
    }
}
