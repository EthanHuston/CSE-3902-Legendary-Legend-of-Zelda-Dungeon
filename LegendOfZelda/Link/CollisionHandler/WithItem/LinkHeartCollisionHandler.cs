using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkHeartCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem item, Constants.Direction side)
        {
            link.BeHealthy(LinkConstants.HeartItemHealAmount);
            item.Despawn();
        }
    }
}
