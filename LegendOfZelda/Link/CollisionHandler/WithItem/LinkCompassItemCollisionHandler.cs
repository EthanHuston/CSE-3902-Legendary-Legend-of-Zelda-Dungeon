using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkCompassItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem compass, Constants.Direction side)
        {
            link.PickupCompass();
            compass.Despawn();
        }
    }
}
