
using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;

namespace LegendOfZelda.Link.Command
{
    internal class ChangeRoomLeftCommand : ICommand
    {
        private readonly RoomGameState rooms;
        public ChangeRoomLeftCommand(RoomGameState rooms)
        {
            this.rooms = rooms;
        }
        public void Execute()
        {
            rooms.MoveRoom(Constants.Direction.Left);
        }
    }
}
