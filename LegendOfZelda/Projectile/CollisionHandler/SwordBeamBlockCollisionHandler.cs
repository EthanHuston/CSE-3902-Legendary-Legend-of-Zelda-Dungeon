using LegendOfZelda.Interface;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    class SwordBeamBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile swordBeam, IBlock block, Constants.Direction side)
        {
            SwordBeamFlyingProjectile swordBeamCast = (SwordBeamFlyingProjectile)swordBeam;
            swordBeamCast.ExplodeSword();
        }
    }
}
