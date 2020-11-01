using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Projectile;

namespace LegendOfZelda.Link.CollisionHandlers.WithProjectile
{
    internal class LinkBombCollisionHandler : ICollisionHandler<IPlayer, IProjectile>
    {
        public void HandleCollision(IPlayer link, IProjectile bomb, Constants.Direction side)
        {
            BombExplodingProjectile bombCast = (BombExplodingProjectile)bomb;
            if (bombCast.IsExploded())
            {
                link.BeDamaged(bombCast.DamageAmount());
            }
        }
    }
}
