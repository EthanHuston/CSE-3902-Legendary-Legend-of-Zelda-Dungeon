
using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Command
{
    class ChangeRoomDownCommand : ICommand
    {
        RoomGameState rooms;
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
