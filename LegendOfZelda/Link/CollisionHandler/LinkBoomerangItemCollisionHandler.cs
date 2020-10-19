using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkBoomerangItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollison(IPlayer link, IItem boomerang, Constants.Direction side)
        {
            link.PickUpBoomerang();
            boomerang.Despawn();
        }
    }
}
