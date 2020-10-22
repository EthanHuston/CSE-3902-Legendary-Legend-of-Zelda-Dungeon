using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkBoomerangItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem boomerang, Constants.Direction side)
        {
            link.PickUpBoomerang();
            boomerang.Despawn();
        }
    }
}
