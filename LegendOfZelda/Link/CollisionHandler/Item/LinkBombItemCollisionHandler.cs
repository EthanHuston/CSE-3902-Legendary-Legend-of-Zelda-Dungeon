using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkBombItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem bomb, Constants.Direction side)
        {
            link.PickupBomb();
            bomb.Despawn();
        }
    }
}
