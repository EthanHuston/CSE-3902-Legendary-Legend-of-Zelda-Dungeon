using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkBowItemCollisionHandler : ICollision<IPlayer, IItem>
    {
        public void HandleCollison(IPlayer link, IItem bow, Constants.Direction side)
        {
            // call methods to make link pick up bow
            // call methods to despawn bow
        }
    }
}
