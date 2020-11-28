using LegendOfZelda.GameState.Command;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.RoomsState
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
            RoomGameState gameStateCast = (RoomGameState)gameState;

            // temporary until we pass in pre-made command dictionary
            IPlayer player = gameStateCast.GetPlayer(0);
            // end temp

            oldGamepadState = new GamePadState();
            buttonMappings = GetButtonMappings(gameState, player);
            repeatableButtons = GetRepeatableButtons();
        }

        private Dictionary<Buttons, ICommand> GetButtonMappings(IGameState gameState, IPlayer player)
        {
            return new Dictionary<Buttons, ICommand>
            {
                { Buttons.LeftThumbstickDown, new MoveDownCommand(player) },
                { Buttons.LeftThumbstickRight, new MoveRightCommand(player) },
                { Buttons.LeftThumbstickLeft, new MoveLeftCommand(player) },
                { Buttons.LeftThumbstickUp, new MoveUpCommand(player) },
                { Buttons.A, new UsePrimaryItemCommand(player) },
                { Buttons.B, new UseSecondaryItemCommand(player) },
                { Buttons.Start, new PauseGameCommand(gameState) },
                { Buttons.X, new ItemSelectCommand(gameState) }
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
                Buttons.LeftThumbstickDown,
                Buttons.LeftThumbstickLeft,
                Buttons.LeftThumbstickUp,
                Buttons.LeftThumbstickRight
            };
        }
    }
}
