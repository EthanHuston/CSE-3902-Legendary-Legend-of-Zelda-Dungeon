using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithBlock
{
    internal class HandBlockCollisionHandler : ICollisionHandler<INpc, IBlock>
    {
        public void HandleCollision(INpc enemy, IBlock block, Constants.Direction side)
        {
            // no collision handling
        }
    }
}
