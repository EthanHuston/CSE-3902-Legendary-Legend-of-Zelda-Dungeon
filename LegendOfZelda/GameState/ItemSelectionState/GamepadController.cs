using System.Collections.Generic;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.GameState.PauseState;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.GameState.ItemSelectionState
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

        public GamepadController(IGameState gameState)
        {
            oldGamepadState = new GamePadState();
            buttonMappings = GetGamepadMappings(gameState);
            repeatableButtons = GetRepeatableButtons();
        }

        private Dictionary<Buttons, ICommand> GetGamepadMappings(IGameState gameState)
        {
            ItemSelectionGameState gameStateCast = (ItemSelectionGameState)gameState;
            ICommand resumeGameCommand = new ResumeGameCommand(gameState);
            return new Dictionary<Buttons, ICommand>
            {
                { Buttons.B, resumeGameCommand },
                { Buttons.X, resumeGameCommand },
                { Buttons.LeftThumbstickUp, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Up) },
                { Buttons.LeftThumbstickRight, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Right) },
                { Buttons.LeftThumbstickDown, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Down) },
                { Buttons.LeftThumbstickLeft, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Left) },
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
