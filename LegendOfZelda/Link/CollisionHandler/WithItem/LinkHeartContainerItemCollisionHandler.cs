using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    internal class LinkHeartContainerItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem heartContainer, Constants.Direction side)
        {
            link.PickUpHeartContainer();
            heartContainer.Despawn();
        }
    }
}
