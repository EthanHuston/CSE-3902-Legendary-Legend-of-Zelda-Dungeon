using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkHeartContainerItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem heartContainer, Constants.Direction side)
        {
            link.PickUpHeartContainer();
            heartContainer.Despawn();
        }
    }
}
