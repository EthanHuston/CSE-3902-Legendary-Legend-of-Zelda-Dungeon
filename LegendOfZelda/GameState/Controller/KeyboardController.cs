using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Controller
{
    internal class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> controllerMappings;
        private KeyboardState oldKeyboardState;
        private readonly List<Keys> repeatableKeys;

        public InputType InputType { get; } = InputType.Keyboard;
        public InputStates OldInputState
        {
            get => new InputStates { KeyboardState = oldKeyboardState };
            set => oldKeyboardState = value.KeyboardState;
        }

        public KeyboardController(Dictionary<Keys, ICommand> keyboardMappings, List<Keys> repeatableKeyboardKeys)
        {
            oldKeyboardState = new KeyboardState();
            controllerMappings = keyboardMappings;
            repeatableKeys = repeatableKeyboardKeys;
        }

        public void Update()
        {
            KeyboardState newKeyboardState = Keyboard.GetState();
            KeyboardState localOldKeyboardState = oldKeyboardState;
            oldKeyboardState = newKeyboardState;

            Keys[] pressedKeys = newKeyboardState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                bool inOldKbState = localOldKeyboardState.IsKeyDown(key);
                bool repeatableKey = repeatableKeys.Contains(key);
                if (controllerMappings.ContainsKey(key) && (!inOldKbState || repeatableKey))
                {
                    controllerMappings[key].Execute();
                }
            }
        }
    }
}
