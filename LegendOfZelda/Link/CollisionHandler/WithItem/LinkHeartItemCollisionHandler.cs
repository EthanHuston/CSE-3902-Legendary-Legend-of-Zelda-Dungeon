﻿using LegendOfZelda.GameLogic;
using LegendOfZelda.Item;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    internal class LinkHeartItemCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem heart, Constants.Direction side)
        {
            link.PickupHeart();
            heart.Despawn();
        }
    }
}
