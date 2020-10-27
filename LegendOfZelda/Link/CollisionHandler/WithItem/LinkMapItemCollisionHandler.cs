using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    internal class LinkMapItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem map, Constants.Direction side)
        {
            link.PickupMap();
            map.Despawn();
        }
    }
}
