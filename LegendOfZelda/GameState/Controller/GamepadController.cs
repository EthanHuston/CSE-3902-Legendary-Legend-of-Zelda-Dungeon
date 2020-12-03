using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Controller
{
    class GamepadController : IController
    {
        private readonly Dictionary<Buttons, ICommand> buttonMappings;
        private GamePadState oldGamepadState;
        private readonly List<Buttons> repeatableButtons;

        public InputType InputType { get; } = InputType.Gamepad;
        public InputStates OldInputState
        {
            get => new InputStates { GamePadState = oldGamepadState };
            set => oldGamepadState = value.GamePadState;
        }

        public GamepadController(Dictionary<Buttons, ICommand> gamepadMappings, List<Buttons> repeatableGamepadButtons)
        {
            oldGamepadState = new GamePadState();
            buttonMappings = gamepadMappings;
            repeatableButtons = repeatableGamepadButtons;
        }

        public void Update()
        {
            GamePadState newGamepadState = GamePad.GetState(0, GamePadDeadZone.Circular);
            GamePadState localOldGamePadState = oldGamepadState;
            oldGamepadState = newGamepadState;

            foreach (KeyValuePair<Buttons, ICommand> keyValuePair in buttonMappings)
            {
                if (newGamepadState.IsButtonDown(keyValuePair.Key) &&
                    (!localOldGamePadState.IsButtonDown(keyValuePair.Key) ||
                    repeatableButtons.Contains(keyValuePair.Key)))
                    keyValuePair.Value.Execute();
            }
        }
    }
}
