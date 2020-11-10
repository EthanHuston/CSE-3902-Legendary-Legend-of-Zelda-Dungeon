namespace LegendOfZelda.Environment
{
    internal interface IDoor : IBlock
    {
        bool IsOpen { get; }
        void OpenDoor();
    }
}
