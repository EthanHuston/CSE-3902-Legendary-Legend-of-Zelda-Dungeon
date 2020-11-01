
using LegendOfZelda.GameState.Rooms;
using LegendOfZelda.Interface;

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
