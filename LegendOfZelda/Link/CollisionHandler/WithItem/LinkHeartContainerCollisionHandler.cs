using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    internal class LinkHeartContainerCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem item, Constants.Direction side)
        {
            link.IncreaseMaxHealth(Constants.HeartValue);
            item.Despawn();
        }
    }
}
