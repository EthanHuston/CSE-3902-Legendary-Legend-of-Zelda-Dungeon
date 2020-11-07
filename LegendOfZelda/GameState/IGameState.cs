namespace LegendOfZelda.GameState
{
    internal interface IGameState
    {
        Game1 Game { get; }
        void Update();
        void Draw();
        void SwitchToRoomState();
        void SwitchToPauseState();
        void SwitchToMainMenuState();
        void SwitchToItemSelectionState();
        void SetControllerOldInputState(OldInputState inputFromOldState);
        void StateEntryProcedure();
        void StateExitProcedure();
    }
}
