

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
        void SwitchToItemSelectionState(int playerNum);
        void SwitchToDeathState();
        void SwitchToWinState();
        void SwitchToOptionState();
        void SetControllerOldInputState(InputStates inputFromOldState);
        void StateEntryProcedure();
        void StateExitProcedure();
    }
}
