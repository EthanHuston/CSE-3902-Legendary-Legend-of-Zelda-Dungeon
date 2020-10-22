using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkFairyItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem fairy, Constants.Direction side)
        {
            link.PickupFairy();
            fairy.Despawn();
        }
    }
}
