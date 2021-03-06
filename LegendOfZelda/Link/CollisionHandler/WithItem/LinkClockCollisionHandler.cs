﻿using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.Item;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.Link.CollisionHandler.WithItem
{
    internal class LinkClockCollisionHandler : ICollisionHandler<IPlayer, IItem>
    {
        public void HandleCollision(IPlayer link, IItem item, Constants.Direction side)
        {
            SoundFactory.Instance.CreateClockPickUpSound().Play();
            ((RoomGameState)link.Game.State).ActivateClockMode();
            item.SafeToDespawn = true;
        }
    }
}
