using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkRupeeItemCollision : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem rupee, Constants.Direction side)
        {
            link.PickupRupee();
            rupee.Despawn();
        }
    }
}
