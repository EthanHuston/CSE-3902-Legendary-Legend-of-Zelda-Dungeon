using LegendOfZelda.GameState.Utilities;

namespace LegendOfZelda.GameState
{
    internal interface IController
    {
        void Update();
        InputStates OldInputState { get; set; }
        InputType InputType { get; }
    }
}
