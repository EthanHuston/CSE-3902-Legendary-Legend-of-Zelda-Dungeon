using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkBoomerangItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem boomerang, Constants.Direction side)
        {
            link.PickUpBoomerang();
            boomerang.Despawn();
        }
    }
}
