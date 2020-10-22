using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkBombItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem bomb, Constants.Direction side)
        {
            link.PickupBomb();
            bomb.Despawn();
        }
    }
}
