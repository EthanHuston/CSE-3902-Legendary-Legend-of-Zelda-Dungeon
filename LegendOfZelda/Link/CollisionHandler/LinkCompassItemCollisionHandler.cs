using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkCompassItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem compass, Constants.Direction side)
        {
            link.PickupCompass();
            compass.Despawn();
        }
    }
}
