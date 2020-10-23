
using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Command
{
    class ChangeRoomLeftCommand : ICommand
    {
        RoomManager rooms;
        public ChangeRoomLeftCommand(RoomManager rooms)
        {
            this.rooms = rooms;
        }
        public void Execute()
        {
            rooms.MoveRoom(Constants.Direction.Left);
        }
    }
}
