using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    class LinkFireCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            link.BeDamaged(Constants.FireTileDamage);
        }
    }
}
