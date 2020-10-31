
using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;

namespace LegendOfZelda.Link.Command
{
    internal class ChangeRoomDownCommand : ICommand
    {
        private readonly RoomGameState rooms;
        public ChangeRoomDownCommand(RoomGameState rooms)
        {
            this.rooms = rooms;
        }
        public void Execute()
        {
            rooms.MoveRoom(Constants.Direction.Down);
        }
    }
}
