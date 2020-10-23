using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Link.CollisionHandler.WithProjectile
{
    class LinkProjectileDoNothingCollisionHandler : ICollisionHandler<IPlayer, IProjectile>
    {
        public void HandleCollision(IPlayer player, IProjectile projectile, Constants.Direction side)
        {
        }
    }
}
