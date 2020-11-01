using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    class LinkFairyCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem item, Constants.Direction side)
        {
            link.GiveFullHealth();
            item.Despawn();
        }
    }
}
