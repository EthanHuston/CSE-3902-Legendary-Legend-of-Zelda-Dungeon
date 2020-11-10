using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Button
{
    internal interface IButton : ISpawnable
    {
        bool IsActive { get; }
        void MakeActive();
        void MakeInactive();
    }
}
