using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Rooms;

namespace LegendOfZelda.Link.CollisionHandler.WithBlock
{
    internal class LinkRoomChangeTriggerCollisionHandler : ICollisionHandler<IPlayer, IBlock>
    {
        public void HandleCollision(IPlayer link, IBlock roomChangeTrigger, Constants.Direction side)
        {
            RoomGameState roomGameState = (RoomGameState)link.Game.State;
            RoomChangeTrigger roomChangeTriggerCast = (RoomChangeTrigger)roomChangeTrigger;

            if (roomGameState.CurrentRoom.GetRoom(roomChangeTriggerCast.Side) == null) new LinkImmovableBlockCollisionHandler().HandleCollision(link, roomChangeTrigger, side);
            else roomGameState.MoveRoom(roomChangeTriggerCast.Side);
        }
    }
}
