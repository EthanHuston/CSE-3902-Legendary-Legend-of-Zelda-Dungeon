using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkFairyItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem fairy, Constants.Direction side)
        {
            link.PickupFairy();
            fairy.Despawn();
        }
    }
}
