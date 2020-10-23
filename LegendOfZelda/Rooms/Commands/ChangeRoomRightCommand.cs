
using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Command
{
    class ChangeRoomRightCommand : ICommand
    {
        RoomManager rooms;
        Point mousePosition;
        public ChangeRoomRightCommand(RoomManager rooms)
        {
            this.rooms = rooms;
        }
        public void Execute()
        {
            rooms.MoveRoom(Constants.Direction.Right);
        }
    }
}
