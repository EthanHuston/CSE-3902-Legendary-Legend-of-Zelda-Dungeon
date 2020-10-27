﻿using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    internal class LinkDoorCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        private const int linkMoveDistance = 1;

        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            // not implemented yet, but call some command to switch rooms
        }
    }
}
