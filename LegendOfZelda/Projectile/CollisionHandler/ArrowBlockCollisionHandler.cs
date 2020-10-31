using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;

namespace LegendOfZelda.Projectile.CollisionHandler
{
    internal class ArrowBlockCollisionHandler : ICollisionHandler<IProjectile, IBlock>
    {
        public void HandleCollision(IProjectile arrow, IBlock block, Constants.Direction side)
        {
            if (block.GetType() == typeof(TileWater)) return;
            arrow.Despawn();
        }
    }
}
