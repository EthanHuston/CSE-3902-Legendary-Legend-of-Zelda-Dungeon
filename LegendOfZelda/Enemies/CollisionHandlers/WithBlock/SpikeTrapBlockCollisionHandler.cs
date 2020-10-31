using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithBlock
{
    internal class SpikeTrapBlockCollisionHandler : ICollisionHandler<INpc, IBlock>
    {
        public void HandleCollision(INpc enemy, IBlock block, Constants.Direction side)
        {
            // all of these are handled in SpikeTrap
        }
    }
}
