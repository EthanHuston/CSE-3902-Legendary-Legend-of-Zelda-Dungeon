using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.PauseState
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

        private Dictionary<Keys, ICommand> GetKeyboardMappings(IGameState gameState)
        {
            PauseGameState gameStateCast = (PauseGameState)gameState;
            return new Dictionary<Keys, ICommand>
            {
                { Keys.Escape, new ResumeGameCommand(gameState) },
                { Keys.W, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Up) },
                { Keys.D, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Right) },
                { Keys.S, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Down) },
                { Keys.A, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Left) },
                { Keys.Enter, new SelectButtonCommand(gameStateCast.PauseGameMenu.ButtonSelector, GetButtonMappings(gameState)) }
            };
        }

        private Dictionary<Type, ICommand> GetButtonMappings(IGameState gameState)
        {
            return new Dictionary<Type, ICommand>
            {
                {typeof(ResumeButton), new ResumeGameCommand(gameState) },
                {typeof(MainMenuButton), new MainMenuCommand(gameState) },
                {typeof(ExitButton), new ExitGameCommand(gameState) }
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
