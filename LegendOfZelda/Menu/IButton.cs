using LegendOfZelda.Interface;

namespace LegendOfZelda.Menu
{
    internal interface IButton : ISpawnable
    {
        bool IsActive { get; }
        void MakeActive();
        void MakeInactive();
    }
}
