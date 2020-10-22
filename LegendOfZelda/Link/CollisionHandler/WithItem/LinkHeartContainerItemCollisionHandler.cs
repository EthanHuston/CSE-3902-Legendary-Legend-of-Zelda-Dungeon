using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkHeartContainerItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem heartContainer, Constants.Direction side)
        {
            link.PickUpHeartContainer();
            heartContainer.Despawn();
        }
    }
}
