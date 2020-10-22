using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    class LinkFireCollisionHandler : ICollision<IPlayer, IBlock>
    {
        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            link.BeDamaged(1);
        }
    }
}
