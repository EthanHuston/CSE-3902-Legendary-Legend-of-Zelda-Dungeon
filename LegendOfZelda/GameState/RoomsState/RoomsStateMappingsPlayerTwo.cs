using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.RoomsState
{
    internal class RoomsStateMappingsPlayerTwo : IGameStateControllerMappings
    {
        public Dictionary<Keys, ICommand> KeyboardMappings { get; private set; }
        public Dictionary<MouseButton, ICommand> MouseMappings { get; private set; }
        public Dictionary<Buttons, ICommand> GamepadMappings { get; private set; }
        public Dictionary<Type, ICommand> ButtonMappings { get; private set; }
        public List<Keys> RepeatableKeyboardKeys { get; private set; }
        public List<Buttons> RepeatableGamepadButtons { get; private set; }

        public RoomsStateMappingsPlayerTwo(IGameState gameState, IPlayer player)
        {
            GamepadMappings = GetGamepadMappings(gameState, player);
            KeyboardMappings = GetKeyboardMappings(gameState, player);
            MouseMappings = GetMouseMappings();
            ButtonMappings = GetButtonMappings();
            RepeatableKeyboardKeys = GetRepeatableKeyboardKeys();
            RepeatableGamepadButtons = GetRepeatableGamepadButtons();
        }

        private Dictionary<Buttons, ICommand> GetGamepadMappings(IGameState gameState, IPlayer player)
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
                { Buttons.X, new ItemSelectCommand(gameState, player.PlayerNumber) }
            };
        }

        public Dictionary<Keys, ICommand> GetKeyboardMappings(IGameState gameState, IPlayer player)
        {
            return new Dictionary<Keys, ICommand>
            {
                { Keys.Escape, new PauseGameCommand(gameState) },
                { Keys.D0, new ItemSelectCommand(gameState, player.PlayerNumber) },

                // Register Player 1 Commands
                { Keys.U, new UsePrimaryItemCommand(player) },
                { Keys.O, new UseSecondaryItemCommand(player) },
                { Keys.I, new MoveUpCommand(player) },
                { Keys.L, new MoveRightCommand(player) },
                { Keys.K, new MoveDownCommand(player) },
                { Keys.J, new MoveLeftCommand(player) },
                { Keys.Up, new MoveUpCommand(player) },
                { Keys.Right, new MoveRightCommand(player) },
                { Keys.Down, new MoveDownCommand(player) },
                { Keys.Left, new MoveLeftCommand(player) },

                /* Keys to change rooms for debugging 
                { Keys.NumPad8, new ChangeRoomUpCommand((RoomGameState)gameState) },
                { Keys.NumPad6, new ChangeRoomRightCommand((RoomGameState)gameState) },
                { Keys.NumPad2, new ChangeRoomDownCommand((RoomGameState)gameState) },
                { Keys.NumPad4, new ChangeRoomLeftCommand((RoomGameState)gameState) },
                { Keys.I, new ChangeRoomUpCommand((RoomGameState)gameState) },
                { Keys.L, new ChangeRoomRightCommand((RoomGameState)gameState) },
                { Keys.K, new ChangeRoomDownCommand((RoomGameState)gameState) },
                { Keys.J, new ChangeRoomLeftCommand((RoomGameState)gameState) }
                /**/
            };
        }
        private Dictionary<Type, ICommand> GetButtonMappings() { return new Dictionary<Type, ICommand>(); }

        private Dictionary<MouseButton, ICommand> GetMouseMappings() { return new Dictionary<MouseButton, ICommand>(); }

        private List<Keys> GetRepeatableKeyboardKeys()
        {
            return new List<Keys>
            {
                Keys.I,
                Keys.L,
                Keys.K,
                Keys.J,
                Keys.Up,
                Keys.Right,
                Keys.Down,
                Keys.Left
            };
        }

        private List<Buttons> GetRepeatableGamepadButtons()
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
