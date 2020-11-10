namespace LegendOfZelda.GameState
{
    interface IController
    {
        void Update();
        OldInputState GetOldInputState();
        GameStateConstants.InputType GetInputType();
        void SetOldInputState(OldInputState oldInputState);
    }
}
