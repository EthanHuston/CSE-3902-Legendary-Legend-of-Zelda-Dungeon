using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkMapItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem map, Constants.Direction side)
        {
            link.PickupMap();
            map.Despawn();
        }
    }
}
