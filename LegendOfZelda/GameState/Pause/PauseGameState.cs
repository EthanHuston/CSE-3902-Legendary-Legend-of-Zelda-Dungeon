using LegendOfZelda.GameState.MainMenu;
using LegendOfZelda.Interface;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Pause
{
    class PauseGameState : IGameState
    {
        private readonly IGameState roomStatePreserved;
        private List<IController> controllerList;
        private List<ISpawnable> buttons;

        public Game1 Game { get; private set; }

        public PauseGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = oldRoomState;
            InitButtonsList();
            InitControllerList();
        }

        private void InitButtonsList()
        {
            buttons = new List<ISpawnable>()
            {
                {new ResumeButton(Game.SpriteBatch, GameStateConstants.PauseStateResumeButtonLocation) },
                {new MainMenuButton(Game.SpriteBatch, GameStateConstants.PauseStateMainMenuButtonLocation) },
                {new ExitButton(Game.SpriteBatch, GameStateConstants.PauseStateExitButtonLocation) }
            };
        }

        private void InitControllerList()
        {
            controllerList = new List<IController>()
            {
                {new KeyboardController(this) },
                {new MouseController(this, buttons) }
            };
        }

        public void Draw()
        {
            roomStatePreserved.Draw(); // continue to draw the old room in the background
            foreach (ISpawnable button in buttons) button.Draw();
        }

        public void SwitchToPauseState()
        {
            // Already in pause state
        }

        public void SwitchToRoomState()
        {
            Game.SetGameState(roomStatePreserved, GameStateConstants.GetOldInputState(controllerList));
        }

        public void SwitchToMainMenuState()
        {
            Game.SetGameState(new MainMenuGameState(Game), GameStateConstants.GetOldInputState(controllerList));
        }

        public void Update()
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            // don't need to update buttons because they are non animated
            // don't update old room because we don't want anything to move in the background
        }

        public void SetControllerOldInputState(OldInputState oldInputState)
        {
            foreach (IController controller in controllerList) controller.SetOldInputState(oldInputState);
        }
    }
}
