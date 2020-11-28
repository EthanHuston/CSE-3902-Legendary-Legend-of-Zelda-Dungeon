using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.MainMenuState
{
    internal class GamepadController : IController
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

        public GamepadController(IGameState gameState)
        {
            oldGamepadState = new GamePadState();
            buttonMappings = GetGamepadMappings(gameState);
            repeatableButtons = GetRepeatableButtons();
        }

        private Dictionary<Buttons, ICommand> GetGamepadMappings(IGameState gameState)
        {
            ICommand startGameCommand = new StartGameCommand(gameState);
            return new Dictionary<Buttons, ICommand>
            {
                { Buttons.A, startGameCommand },
                { Buttons.Start, startGameCommand },
                { Buttons.B, new ExitGameCommand(gameState) }
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

        private List<Buttons> GetRepeatableButtons()
        {
            return new List<Buttons>()
            {
            };
        }
    }
}
