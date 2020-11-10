using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Button
{
    interface IButton : ISpawnable
    {
        bool IsActive { get; }
        void MakeActive();
        void MakeInactive();
    }
}
