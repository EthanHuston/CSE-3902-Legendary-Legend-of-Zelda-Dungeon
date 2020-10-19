using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkClockItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollison(IPlayer link, IItem clock, Constants.Direction side)
        {
            link.PickupClock();
            clock.Despawn();
        }
    }
}
