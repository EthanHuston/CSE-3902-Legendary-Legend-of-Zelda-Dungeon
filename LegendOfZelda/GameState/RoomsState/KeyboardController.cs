using LegendOfZelda.GameState.Command;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.RoomsState
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
            RoomGameState gameStateCast = (RoomGameState)gameState;
            return new Dictionary<Keys, ICommand>
            {
                { Keys.Escape, new PauseGameCommand(gameState) },
                { Keys.Tab, new ItemSelectCommand(gameState) },

                // Register Player 1 Commands
                { Keys.D1, new UsePrimaryItemCommand(gameStateCast.GetPlayer(0)) },
                { Keys.D2, new UseSecondaryItemCommand(gameStateCast.GetPlayer(0)) },
                { Keys.Q, new UsePrimaryItemCommand(gameStateCast.GetPlayer(0)) },
                { Keys.E, new UseSecondaryItemCommand(gameStateCast.GetPlayer(0)) },
                { Keys.W, new MoveUpCommand(gameStateCast.GetPlayer(0)) },
                { Keys.D, new MoveRightCommand(gameStateCast.GetPlayer(0)) },
                { Keys.S, new MoveDownCommand(gameStateCast.GetPlayer(0)) },
                { Keys.A, new MoveLeftCommand(gameStateCast.GetPlayer(0)) },

                /* Keys to change rooms for debugging
                { Keys.NumPad8, new ChangeRoomUpCommand(gameStateCast) },
                { Keys.NumPad6, new ChangeRoomRightCommand(gameStateCast) },
                { Keys.NumPad2, new ChangeRoomDownCommand(gameStateCast) },
                { Keys.NumPad4, new ChangeRoomLeftCommand(gameStateCast) },
                { Keys.I, new ChangeRoomUpCommand(gameStateCast) },
                { Keys.L, new ChangeRoomRightCommand(gameStateCast) },
                { Keys.K, new ChangeRoomDownCommand(gameStateCast) },
                { Keys.J, new ChangeRoomLeftCommand(gameStateCast) }
                /**/
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
                Keys.W,
                Keys.D,
                Keys.S,
                Keys.A
            };
        }
    }
}
