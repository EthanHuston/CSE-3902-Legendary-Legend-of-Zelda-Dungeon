
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;

namespace LegendOfZelda.Link.Command
{
    internal class ChangeRoomRightCommand : ICommand
    {
        private readonly RoomGameState rooms;
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
