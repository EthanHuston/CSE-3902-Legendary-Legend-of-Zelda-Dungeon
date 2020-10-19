using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkFairyItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollison(IPlayer link, IItem fairy, Constants.Direction side)
        {
            link.PickupFairy();
            fairy.Despawn();
        }
    }
}
