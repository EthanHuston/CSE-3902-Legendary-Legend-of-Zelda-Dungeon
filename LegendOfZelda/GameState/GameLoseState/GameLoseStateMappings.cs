using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.GameLoseState
{
    internal class GameLoseStateMappings : IGameStateControllerMappings
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
            GameLoseGameState gameStateCast = (GameLoseGameState)gameState;
            return new Dictionary<Buttons, ICommand>
            {
                { Buttons.LeftThumbstickUp, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Up) },
                { Buttons.LeftThumbstickRight, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Right) },
                { Buttons.LeftThumbstickDown, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Down) },
                { Buttons.LeftThumbstickLeft, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Left) },
                { Buttons.DPadUp, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Up) },
                { Buttons.DPadRight, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Right) },
                { Buttons.DPadDown, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Down) },
                { Buttons.DPadLeft, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Left) },
                { Buttons.A, new SelectButtonCommand(gameStateCast.GameLoseMenu.ButtonSelector, GetButtonMappings(gameState)) }
            };
        }

        public Dictionary<Keys, ICommand> GetKeyboardMappings(IGameState gameState)
        {
            GameLoseGameState gameStateCast = (GameLoseGameState)gameState;
            return new Dictionary<Keys, ICommand>
            {
                {Keys.Escape, new ExitGameCommand(gameState) },
                { Keys.W, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Up) },
                { Keys.D, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Right) },
                { Keys.S, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Down) },
                { Keys.A, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Left) },
                { Keys.Enter, new SelectButtonCommand(gameStateCast.GameLoseMenu.ButtonSelector, GetButtonMappings(gameState)) },
                { Keys.Space, new SelectButtonCommand(gameStateCast.GameLoseMenu.ButtonSelector, GetButtonMappings(gameState)) },
                {Keys.I, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Up) },
                {Keys.L, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Right) },
                {Keys.K, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Down) },
                {Keys.J, new MoveSelectorCommand(gameStateCast.GameLoseMenu, Constants.Direction.Left) },
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
