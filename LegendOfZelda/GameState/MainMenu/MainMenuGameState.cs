using LegendOfZelda.GameState.Rooms;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.MainMenu
{
    class MainMenuGameState : IGameState
    {
        private List<IController> controllerList;
        public Game1 Game { get; private set; }

        public MainMenuGameState(Game1 game)
        {
            Game = game;
            InitControllerList();
        }

        private void InitControllerList()
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(this) }
            };
        }

        public void Draw()
        {
            // draw background
            // draw button sprites
        }

        public void SwitchToMainMenuState()
        {
            // Already in main menu state
        }

        public void SwitchToPauseState()
        {
            // cannot switch to pause state from here
        }

        public void SwitchToRoomState()
        {
            Game.State = new RoomGameState(Game);
        }

        public void Update()
        {
            // don't update spawnable manager because we don't want anything to move in the background
        }
    }
}
