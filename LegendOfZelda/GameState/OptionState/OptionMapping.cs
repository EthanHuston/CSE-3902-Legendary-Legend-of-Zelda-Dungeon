using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.OptionState
{
    class OptionMapping : IGameStateControllerMappings
    {
        public Dictionary<Keys, ICommand> KeyboardMappings { get; private set; }
        public Dictionary<MouseButton, ICommand> MouseMappings { get; private set; }
        public Dictionary<Buttons, ICommand> GamepadMappings { get; private set; }
        public Dictionary<Type, ICommand> ButtonMappings { get; private set; }
        public List<Keys> RepeatableKeyboardKeys { get; private set; }
        public List<Buttons> RepeatableGamepadButtons { get; private set; }

        public OptionMapping(IGameState gameState)
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
            OptionGameState gameStateCast = (OptionGameState)gameState;
            ICommand resumeGameCommand = new ResumeGameCommand(gameState);
            return new Dictionary<Buttons, ICommand>
            {
                { Buttons.Start, resumeGameCommand },
                { Buttons.B, resumeGameCommand },
                { Buttons.LeftThumbstickUp, new MoveSelectorCommand(gameStateCast.OptionMenu, Constants.Direction.Up) },
                { Buttons.LeftThumbstickRight, new MoveSelectorCommand(gameStateCast.OptionMenu, Constants.Direction.Right) },
                { Buttons.LeftThumbstickDown, new MoveSelectorCommand(gameStateCast.OptionMenu, Constants.Direction.Down) },
                { Buttons.LeftThumbstickLeft, new MoveSelectorCommand(gameStateCast.OptionMenu, Constants.Direction.Left) },
                { Buttons.A, new SelectButtonCommand(gameStateCast.OptionMenu.ButtonSelector, GetButtonMappings(gameState)) }
            };
        }

        public Dictionary<Keys, ICommand> GetKeyboardMappings(IGameState gameState)
        {
            OptionGameState gameStateCast = (OptionGameState)gameState;
            return new Dictionary<Keys, ICommand>
            {
                { Keys.Escape, new ResumeGameCommand(gameState) },
                { Keys.W, new MoveSelectorCommand(gameStateCast.OptionMenu, Constants.Direction.Up) },
                { Keys.D, new MoveSelectorCommand(gameStateCast.OptionMenu, Constants.Direction.Right) },
                { Keys.S, new MoveSelectorCommand(gameStateCast.OptionMenu, Constants.Direction.Down) },
                { Keys.A, new MoveSelectorCommand(gameStateCast.OptionMenu, Constants.Direction.Left) },
                { Keys.Enter, new SelectButtonCommand(gameStateCast.OptionMenu.ButtonSelector, GetButtonMappings(gameState)) }
            };
        }

        private Dictionary<Type, ICommand> GetButtonMappings(IGameState gameState)
        {
            return new Dictionary<Type, ICommand>
            {
                {typeof(AcceptButton), new MainMenuCommand(gameState) }
            };
        }

        private Dictionary<MouseButton, ICommand> GetMouseMappings(IGameState gameState)
        {
            return new Dictionary<MouseButton, ICommand>
            {
                {MouseButton.LeftButton, new StartGameCommand(gameState) }
            };
        }

        private List<Keys> GetRepeatableKeyboardKeys() { return new List<Keys>(); }

        private List<Buttons> GetRepeatableGamepadButtons() { return new List<Buttons>(); }
    }
}
