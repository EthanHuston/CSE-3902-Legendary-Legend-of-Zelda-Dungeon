
using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Command
{
    class ChangeRoomUpCommand : ICommand
    {
        RoomManager rooms;
        public ChangeRoomUpCommand(RoomManager rooms)
        {
            this.rooms = rooms;
        }
        public void Execute()
        {
            rooms.MoveRoom(Constants.Direction.Up);
        }
    }
}
