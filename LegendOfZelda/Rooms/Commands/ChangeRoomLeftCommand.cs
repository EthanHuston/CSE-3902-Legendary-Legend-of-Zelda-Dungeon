
using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.Interface;

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
