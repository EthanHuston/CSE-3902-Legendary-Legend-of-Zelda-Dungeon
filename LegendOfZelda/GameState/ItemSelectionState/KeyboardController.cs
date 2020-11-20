using LegendOfZelda.GameState.Command;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    internal class KeyboardController : IController
    {
        private readonly Dictionary<Keys, ICommand> controllerMappings;
        private KeyboardState oldKbState;
        private readonly List<Keys> repeatableKeys;

        public InputType InputType { get; } = InputType.Keyboard;
        public InputStates OldInputState
        {
            get => new InputStates { KeyboardState = oldKbState };
            set => oldKbState = value.KeyboardState;
        }

        public KeyboardController(IGameState gameState)
        {
            oldKbState = new KeyboardState();
            controllerMappings = GetKeyboardMappings(gameState);
            repeatableKeys = GetRepeatableKeys();
        }

        public Dictionary<Keys, ICommand> GetKeyboardMappings(IGameState gameState)
        {
            ItemSelectionGameState gameStateCast = (ItemSelectionGameState)gameState;
            return new Dictionary<Keys, ICommand>
            {
                {Keys.Tab, new ResumeGameCommand(gameState) },
                {Keys.W, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Up) },
                {Keys.D, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Right) },
                {Keys.S, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Down) },
                {Keys.A, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Left) }
            };
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Keys[] pressedKeys = keyboardState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                bool inOldKbState = oldKbState.IsKeyDown(key);
                bool repeatableKey = repeatableKeys.Contains(key);
                if (controllerMappings.ContainsKey(key) && (!inOldKbState || repeatableKey))
                {
                    controllerMappings[key].Execute();
                }
            }

            oldKbState = keyboardState;
        }

        private List<Keys> GetRepeatableKeys()
        {
            return new List<Keys>()
            {
            };
        }
    }
}
