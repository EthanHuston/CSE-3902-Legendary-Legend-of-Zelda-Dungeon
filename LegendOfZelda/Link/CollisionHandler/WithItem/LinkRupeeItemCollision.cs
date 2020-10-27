using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    internal class LinkRupeeItemCollision : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem rupee, Constants.Direction side)
        {
            link.PickupRupee();
            rupee.Despawn();
        }
    }
}
