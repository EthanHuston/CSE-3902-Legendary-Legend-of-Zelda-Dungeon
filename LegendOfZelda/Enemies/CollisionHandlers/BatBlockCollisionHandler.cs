using LegendOfZelda.Interface;

namespace LegendOfZelda.Enemies.CollisionHandlers
{
    class BatCollisionHandler : ICollision<INpc, IBlock>
    {
        public void HandleCollison(INpc enemy, IBlock block, Constants.Direction side)
        {
            //Do nothing, Bat does not Collide with blocks, just the walls which is taken care of elsewhere.
        }
    }
}
