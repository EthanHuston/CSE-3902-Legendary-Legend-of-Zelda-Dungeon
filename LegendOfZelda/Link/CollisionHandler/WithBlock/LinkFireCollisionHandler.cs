using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    internal class LinkFireCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            link.BeDamaged(Constants.FireTileDamage);
        }
    }
}
