﻿using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.PauseState
{
    internal class PauseStateMappings : IGameStateControllerMappings
    {
        public Dictionary<Keys, ICommand> KeyboardMappings { get; private set; }
        public Dictionary<MouseButton, ICommand> MouseMappings { get; private set; }
        public Dictionary<Buttons, ICommand> GamepadMappings { get; private set; }
        public Dictionary<Type, ICommand> ButtonMappings { get; private set; }
        public List<Keys> RepeatableKeyboardKeys { get; private set; }
        public List<Buttons> RepeatableGamepadButtons { get; private set; }

        public PauseStateMappings(IGameState gameState)
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
            PauseGameState gameStateCast = (PauseGameState)gameState;
            ICommand resumeGameCommand = new ResumeGameCommand(gameState);
            return new Dictionary<Buttons, ICommand>
            {
                { Buttons.Start, resumeGameCommand },
                { Buttons.B, resumeGameCommand },
                { Buttons.LeftThumbstickUp, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Up) },
                { Buttons.LeftThumbstickRight, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Right) },
                { Buttons.LeftThumbstickDown, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Down) },
                { Buttons.LeftThumbstickLeft, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Left) },
                { Buttons.DPadUp, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Up) },
                { Buttons.DPadRight, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Right) },
                { Buttons.DPadDown, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Down) },
                { Buttons.DPadLeft, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Left) },
                { Buttons.A, new SelectButtonCommand(gameStateCast.PauseGameMenu.ButtonSelector, GetButtonMappings(gameState)) }
            };
        }

        public Dictionary<Keys, ICommand> GetKeyboardMappings(IGameState gameState)
        {
            PauseGameState gameStateCast = (PauseGameState)gameState;
            return new Dictionary<Keys, ICommand>
            {
                { Keys.Escape, new ResumeGameCommand(gameState) },
                { Keys.W, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Up) },
                { Keys.D, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Right) },
                { Keys.S, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Down) },
                { Keys.A, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Left) },
                { Keys.Enter, new SelectButtonCommand(gameStateCast.PauseGameMenu.ButtonSelector, GetButtonMappings(gameState)) },
                { Keys.Space, new SelectButtonCommand(gameStateCast.PauseGameMenu.ButtonSelector, GetButtonMappings(gameState)) },
                {Keys.I, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Up) },
                {Keys.L, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Right) },
                {Keys.K, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Down) },
                {Keys.J, new MoveSelectorCommand(gameStateCast.PauseGameMenu, Constants.Direction.Left) },
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
