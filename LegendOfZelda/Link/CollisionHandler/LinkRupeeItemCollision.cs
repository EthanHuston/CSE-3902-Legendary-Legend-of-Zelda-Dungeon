using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.CollisionHandler
{
    class LinkRupeeItemCollision : ICollision<IPlayer, IItem>
    {
        public void HandleCollison(IPlayer link, IItem rupee, Constants.Direction side)
        {
            link.PickupRupee();
            rupee.Despawn();
        }
    }
}
