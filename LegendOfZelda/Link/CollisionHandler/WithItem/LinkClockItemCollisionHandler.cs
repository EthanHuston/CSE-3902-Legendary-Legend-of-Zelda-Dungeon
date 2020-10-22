using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkClockItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem clock, Constants.Direction side)
        {
            link.PickupClock();
            clock.Despawn();
        }
    }
}
