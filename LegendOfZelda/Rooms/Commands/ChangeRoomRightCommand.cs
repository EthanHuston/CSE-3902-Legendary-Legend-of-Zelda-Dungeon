
using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Command
{
    class ChangeRoomRightCommand : ICommand
    {
        RoomGameState rooms;
        public ChangeRoomRightCommand(RoomGameState rooms)
        {
            this.rooms = rooms;
        }
        public void Execute()
        {
            rooms.MoveRoom(Constants.Direction.Right);
        }
    }
}
