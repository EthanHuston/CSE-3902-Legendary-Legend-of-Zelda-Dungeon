using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkHeartItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem heart, Constants.Direction side)
        {
            link.PickupHeart();
            heart.Despawn();
        }
    }
}
