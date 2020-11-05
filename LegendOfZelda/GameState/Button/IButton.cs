using LegendOfZelda.Interface;

namespace LegendOfZelda.GameState.Button
{
    interface IButton : ISpawnable
    {
        void MakeActive();
        void MakeInactive();
    }
}
