using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkHeartItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollison(IPlayer link, IItem heart, Constants.Direction side)
        {
            link.PickupHeart();
            heart.Despawn();
        }
    }
}
