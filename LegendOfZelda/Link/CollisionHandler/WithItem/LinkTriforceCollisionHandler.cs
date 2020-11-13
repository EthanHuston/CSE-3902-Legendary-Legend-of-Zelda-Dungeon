using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;
using LegendOfZelda.Link.Interface;
using System;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    internal class LinkTriforceCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem item, Constants.Direction side)
        {
            link.PickupTriforce();
            link.Game.State.SwitchToWinState();
        }
    }
}
