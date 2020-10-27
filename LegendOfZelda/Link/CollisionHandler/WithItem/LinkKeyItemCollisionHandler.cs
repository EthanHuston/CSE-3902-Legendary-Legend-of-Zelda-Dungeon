using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkKeyItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem key, Constants.Direction side)
        {
            link.PickupKey();
            key.Despawn();
        }
    }
}
