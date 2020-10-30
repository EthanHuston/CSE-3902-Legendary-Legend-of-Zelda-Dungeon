using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem item, Constants.Direction side)
        {
            link.PickupItem(item.GetItemType());
            item.Despawn();
        }
    }
}
