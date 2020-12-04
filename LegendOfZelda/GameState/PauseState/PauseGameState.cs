using LegendOfZelda.GameState.Controller;
using LegendOfZelda.GameState.MainMenuState;
using LegendOfZelda.Menu;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.PauseState
{
    internal class PauseGameState : IGameState
    {
        private readonly List<IController> controllerList;
        private readonly IGameState roomStatePreserved;

        public Game1 Game { get; private set; }
        public IButtonMenu PauseGameMenu { get; private set; }

        public PauseGameState(Game1 game, IGameState oldRoomState)
        {
            Game = game;
            roomStatePreserved = oldRoomState;
            PauseGameMenu = new PauseGameMenu(Game);
            controllerList = GetControllerList();
        }

        private List<IController> GetControllerList()
        {
            IGameStateControllerMappings mappings = new PauseStateMappings(this);
            return new List<IController>()
            {
                {new KeyboardController(mappings.KeyboardMappings, mappings.RepeatableKeyboardKeys) },
                {new MouseController(mappings.MouseMappings, mappings.ButtonMappings, PauseGameMenu.Buttons) },
                {new GamepadController(mappings.GamepadMappings, mappings.RepeatableGamepadButtons) }
            };
        }

        public void Draw()
        {
            roomStatePreserved.Draw(); // continue to draw the old room in the background
            PauseGameMenu.Draw();
        }

        public void SwitchToRoomState()
        {
            StateExitProcedure();
            Game.State = roomStatePreserved;
            Game.State.SetControllerOldInputState(GameStateMethods.GetOldInputState(controllerList));
            Game.State.StateEntryProcedure();
        }

        public void SwitchToMainMenuState()
        {
            StateExitProcedure();
            Game.State = new MainMenuGameState(Game);
            Game.State.SetControllerOldInputState(GameStateMethods.GetOldInputState(controllerList));
            Game.State.StateEntryProcedure();
        }

        public void StateEntryProcedure()
        {
            // nothing fancy to do here
        }

        public void StateExitProcedure()
        {
            // nothing fancy to do here
        }

        public void Update()
        {
            foreach (IController controller in controllerList) controller.Update();
            PauseGameMenu.Update();
        }

        public void SwitchToPauseState() { }

        public void SwitchToItemSelectionState(int playerNum) { }

        public void SwitchToDeathState() { }

        public void SwitchToWinState() { }

        public void SetControllerOldInputState(InputStates inputFromOldState)
        {
            foreach (IController controller in controllerList) controller.OldInputState = inputFromOldState;
        }

        public void SwitchToOptionState() { }
    }
}
