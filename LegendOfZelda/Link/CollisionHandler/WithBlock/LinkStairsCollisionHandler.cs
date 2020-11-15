using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Link.Interface;
using System;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    internal class LinkStairsCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        public void HandleCollision(IPlayer link, IBlock block, Constants.Direction side)
        {
            SoundFactory.Instance.CreateStairsSound();
            ((RoomGameState)link.Game.State).MoveRoom(Constants.Direction.Stairs);
        }
    }
}
