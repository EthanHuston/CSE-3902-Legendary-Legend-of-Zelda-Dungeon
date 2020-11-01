using LegendOfZelda.GameLogic;
using LegendOfZelda.GameState;
using LegendOfZelda.GameState.MainMenu;
using LegendOfZelda.Link.Interface;

namespace LegendOfZelda.GameState.Pause
{
    class PauseGameState : IGameState
    {
        private readonly IGameState roomStatePreserved;

        public Game1 Game { get; private set; }

        public PauseGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = oldRoomState;
        }

        public void Draw()
        {
            roomStatePreserved.Draw(); // continue to draw the old room in the background
            // draw buttons next (quit game, resume game)
        }

        public void SwitchToPauseState()
        {
            // Already in pause state
        }

        public void SwitchToRoomState()
        {
            Game.State = roomStatePreserved;
        }

        public void Update()
        {
            // don't update old room because we don't want anything to move in the background
        }

        public void SwitchToMainMenuState()
        {
            Game.State = new MainMenuGameState(Game);
        }
    }
}
