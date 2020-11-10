using LegendOfZelda.Interface;

namespace LegendOfZelda.Environment
{
    interface IDoor : IBlock
    {
        bool IsOpen { get; }
        void OpenDoor();
    }
}
