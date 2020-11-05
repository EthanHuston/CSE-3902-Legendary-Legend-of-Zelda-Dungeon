using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    internal class LinkDoorCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            // not implemented yet, but call some command to switch rooms
        }
    }
}
