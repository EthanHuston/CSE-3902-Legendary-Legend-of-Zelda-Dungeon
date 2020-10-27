using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;

namespace LegendOfZelda.Enemies.CollisionHandlers.WithBlock
{
    internal class BatBlockCollisionHandler : ICollisionHandler<INpc, IBlock>
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
