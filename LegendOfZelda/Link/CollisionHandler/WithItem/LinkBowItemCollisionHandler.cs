using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    internal class LinkBowItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem bow, Constants.Direction side)
        {
            link.PickUpBow();
            bow.Despawn();
        }
    }
}
