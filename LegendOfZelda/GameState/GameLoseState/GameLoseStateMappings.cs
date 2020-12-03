using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.GameLoseState
{
    class GameLoseStateMappings : IGameStateControllerMappings
    {
        public Dictionary<Keys, ICommand> KeyboardMappings { get; private set; }
        public Dictionary<MouseButton, ICommand> MouseMappings { get; private set; }
        public Dictionary<Buttons, ICommand> GamepadMappings { get; private set; }
        public Dictionary<Type, ICommand> ButtonMappings { get; private set; }
        public List<Keys> RepeatableKeyboardKeys { get; private set; }
        public List<Buttons> RepeatableGamepadButtons { get; private set; }

        public GameLoseStateMappings(IGameState gameState)
        {
            GamepadMappings = GetGamepadMappings(gameState);
            KeyboardMappings = GetKeyboardMappings(gameState);
            MouseMappings = GetMouseMappings();
            ButtonMappings = GetButtonMappings(gameState);
            RepeatableKeyboardKeys = GetRepeatableKeyboardKeys();
            RepeatableGamepadButtons = GetRepeatableGamepadButtons();
        }

        private Dictionary<Buttons, ICommand> GetGamepadMappings(IGameState gameState)
        {
            return new Dictionary<Buttons, ICommand>
            {
                /* TODO: add select/moves button commands here */
            };
        }

        public Dictionary<Keys, ICommand> GetKeyboardMappings(IGameState gameState)
        {
            return new Dictionary<Keys, ICommand>
            {
                {Keys.Escape, new ExitGameCommand(gameState) }
            };
        }

        private Dictionary<Type, ICommand> GetButtonMappings(IGameState gameState)
        {
            return new Dictionary<Type, ICommand>
            {
                {typeof(RetryButtonBlack), new MainMenuCommand(gameState) },
                {typeof(ExitButtonBlack), new ExitGameCommand(gameState) }
            };
        }

        private Dictionary<MouseButton, ICommand> GetMouseMappings() { return new Dictionary<MouseButton, ICommand>(); }

        private List<Keys> GetRepeatableKeyboardKeys() { return new List<Keys>(); }

        private List<Buttons> GetRepeatableGamepadButtons() { return new List<Buttons>(); }
    }
}
