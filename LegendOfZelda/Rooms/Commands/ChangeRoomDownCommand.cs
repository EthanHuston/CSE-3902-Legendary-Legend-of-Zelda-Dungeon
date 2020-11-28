
using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.Interface;

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
