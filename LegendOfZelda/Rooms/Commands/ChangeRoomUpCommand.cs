
using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Command
{
    class ChangeRoomUpCommand : ICommand
    {
        RoomGameState rooms;
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
