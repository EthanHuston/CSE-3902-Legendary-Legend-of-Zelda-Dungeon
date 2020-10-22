using LegendOfZelda.Interface;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithBlock
{
    class BatBlockCollisionHandler : ICollisionHandler<INpc, IBlock>
    {
        public void HandleCollision(INpc enemy, IBlock block, Constants.Direction side)
        {
            //Do nothing, Bat does not Collide with blocks, just the walls which is taken care of elsewhere.
        }
    }
}
