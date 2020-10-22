using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkKeyItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem key, Constants.Direction side)
        {
            link.PickupKey();
            key.Despawn();
        }
    }
}
