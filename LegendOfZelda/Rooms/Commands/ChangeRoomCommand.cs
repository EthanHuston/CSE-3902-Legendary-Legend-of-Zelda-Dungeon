
using LegendOfZelda.Interface;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Link.Command
{
    class ChangeRoomCommand : ICommand
    {
        RoomManager rooms;
        public ChangeRoomCommand(RoomManager rooms, Point mousePosition)
        {
            this.rooms = rooms;
        }
        public void Execute()
        {
            
        }
    }
}
