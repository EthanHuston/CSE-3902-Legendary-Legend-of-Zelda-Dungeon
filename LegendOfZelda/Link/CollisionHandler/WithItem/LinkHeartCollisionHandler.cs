using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    internal class LinkHeartCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem item, Constants.Direction side)
        {
            SoundFactory.Instance.CreateGetHeartSound().Play();
            link.BeHealthy(LinkConstants.HeartItemHealAmount);
            item.SafeToDespawn = true;
        }
    }
}
