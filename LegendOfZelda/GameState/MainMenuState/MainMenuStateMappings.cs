using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.MainMenuState
{
    internal class MainMenuStateMappings : IGameStateControllerMappings
    {
        public Dictionary<Keys, ICommand> KeyboardMappings { get; private set; }
        public Dictionary<MouseButton, ICommand> MouseMappings { get; private set; }
        public Dictionary<Buttons, ICommand> GamepadMappings { get; private set; }
        public Dictionary<Type, ICommand> ButtonMappings { get; private set; }
        public List<Keys> RepeatableKeyboardKeys { get; private set; }
        public List<Buttons> RepeatableGamepadButtons { get; private set; }

        public MainMenuStateMappings(IGameState gameState)
        {
            GamepadMappings = GetGamepadMappings(gameState);
            KeyboardMappings = GetKeyboardMappings(gameState);
            MouseMappings = GetMouseMappings(gameState);
            ButtonMappings = GetButtonMappings(gameState);
            RepeatableKeyboardKeys = GetRepeatableKeyboardKeys();
            RepeatableGamepadButtons = GetRepeatableGamepadButtons();
        }

        private Dictionary<Buttons, ICommand> GetGamepadMappings(IGameState gameState)
        {
            ICommand optionCommand = new OptionCommand(gameState);
            return new Dictionary<Buttons, ICommand>
            {
                { Buttons.A, optionCommand },
                { Buttons.Start, optionCommand },
                { Buttons.B, new ExitGameCommand(gameState) }
            };
        }

        public Dictionary<Keys, ICommand> GetKeyboardMappings(IGameState gameState)
        {
            return new Dictionary<Keys, ICommand>
            {
                {Keys.Escape, new ExitGameCommand(gameState) },
                {Keys.Space, new OptionCommand(gameState) }
            };
        }

        private Dictionary<Type, ICommand> GetButtonMappings(IGameState gameState) { return new Dictionary<Type, ICommand>(); }

        private Dictionary<MouseButton, ICommand> GetMouseMappings(IGameState gameState)
        {
            return new Dictionary<MouseButton, ICommand>
            {
                {MouseButton.LeftButton, new OptionCommand(gameState) }
            };
        }

        private List<Keys> GetRepeatableKeyboardKeys() { return new List<Keys>(); }

        private List<Buttons> GetRepeatableGamepadButtons() { return new List<Buttons>(); }
    }
}
