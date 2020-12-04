using LegendOfZelda.GameState.Controller;
using LegendOfZelda.GameState.MainMenuState;
using LegendOfZelda.Menu;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.OptionState
{
    class OptionGameState : IGameState
    {
        private readonly List<IController> controllerList;


        private bool usePokemonSprites;
        public bool UsePokemonSprites { get => usePokemonSprites; set => usePokemonSprites = value; }

        private bool useJojoReferences;
        public bool UseJojoReferences {
            get => useJojoReferences;
            set
            {
                useJojoReferences = true; // invert these because you can only use one at a time
                useYakuzaReferences = false;
            }
        }

        private bool useYakuzaReferences;
        public bool UseYakuzaReferences
        {
            get => useYakuzaReferences;
            set
            {
                useYakuzaReferences = true; // invert these because you can only use one at a time
                useJojoReferences = false;
            }
        }

        public Game1 Game { get; private set; }
        public IButtonMenu OptionMenu { get; private set; }

        public OptionGameState(Game1 game)
        {
            Game = game;
            OptionMenu = new OptionMenu(Game);
            controllerList = GetControllerList();
        }

        private List<IController> GetControllerList()
        {
            IGameStateControllerMappings mappings = new OptionMapping(this);
            return new List<IController>()
            {
                {new KeyboardController(mappings.KeyboardMappings, mappings.RepeatableKeyboardKeys) },
                {new MouseController(mappings.MouseMappings, mappings.ButtonMappings, OptionMenu.Buttons) },
                {new GamepadController(mappings.GamepadMappings, mappings.RepeatableGamepadButtons) }
            };
        }

        public void Draw()
        {
            OptionMenu.Draw();
        }

        public void SwitchToRoomState()
        {
            StateExitProcedure();
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
            OptionMenu.Update();
        }

        public void SwitchToPauseState() { }

        public void SwitchToItemSelectionState() { }

        public void SwitchToDeathState() { }

        public void SwitchToWinState() { }

        public void SetControllerOldInputState(InputStates inputFromOldState)
        {
            foreach (IController controller in controllerList) controller.OldInputState = inputFromOldState;
        }
    }
}
