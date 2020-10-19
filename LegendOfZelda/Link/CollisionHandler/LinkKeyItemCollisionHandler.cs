using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkKeyItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollison(IPlayer link, IItem key, Constants.Direction side)
        {
            link.PickupKey();
            key.Despawn();
        }
    }
}
