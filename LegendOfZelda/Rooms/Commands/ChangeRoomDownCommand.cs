
using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Command
{
    class ChangeRoomDownCommand : ICommand
    {
        RoomManager rooms;
        public ChangeRoomDownCommand(RoomManager rooms)
        {
            this.rooms = rooms;
        }
        public void Execute()
        {
            rooms.MoveRoom(Constants.Direction.Down);
        }
    }
}
