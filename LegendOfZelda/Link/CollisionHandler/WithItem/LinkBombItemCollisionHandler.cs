using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;

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
