using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Link.CollisionHandler.WithProjectile
{
    internal class LinkProjectileDoNothingCollisionHandler : ICollisionHandler<IPlayer, IProjectile>
    {
        public void HandleCollision(IPlayer player, IProjectile projectile, Constants.Direction side)
        {
        }
    }
}
