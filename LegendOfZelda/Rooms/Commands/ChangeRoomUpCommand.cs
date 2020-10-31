
using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;

namespace LegendOfZelda.Link.Command
{
    internal class ChangeRoomUpCommand : ICommand
    {
        private readonly RoomGameState rooms;
        public ChangeRoomUpCommand(RoomGameState rooms)
        {
            this.rooms = rooms;
        }
        public void Execute()
        {
            rooms.MoveRoom(Constants.Direction.Up);
        }
    }
}
