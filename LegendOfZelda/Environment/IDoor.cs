using LegendOfZelda.Interface;
using LegendOfZelda.Rooms.RoomImplementation;

namespace LegendOfZelda.Environment
{
    interface IDoor : IBlock
    {
        Constants.Direction Side { get; }
        bool IsOpen { get; }
        void OpenDoor();
        void CloseDoor();
        Room Location { get; }
    }
}
