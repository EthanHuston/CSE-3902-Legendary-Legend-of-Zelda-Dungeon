using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithBlock
{
    class BatBlockCollisionHandler : ICollisionHandler<INpc, IBlock>
    {
        public void HandleCollision(INpc enemy, IBlock block, Constants.Direction side)
        {
            if (block.GetType() == typeof(RoomWall))
            {
                ((Bat)enemy).ChooseDirection();
            }
        }
    }
}
