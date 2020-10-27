using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    class ArrowBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile arrow, IBlock block, Constants.Direction side)
        {
            arrow.Despawn();
        }
    }
}
