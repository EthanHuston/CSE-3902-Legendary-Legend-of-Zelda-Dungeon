namespace LegendOfZelda.GameState
{
    internal interface IController
    {
        void Update();
        OldInputState GetOldInputState();
        GameStateConstants.InputType GetInputType();
        void SetOldInputState(OldInputState oldInputState);
    }
}
