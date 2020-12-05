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
            KeyboardMappings = GetKeyboardMappings();
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

        public Dictionary<Keys, ICommand> GetKeyboardMappings() { return new Dictionary<Keys, ICommand>(); }

        private Dictionary<Type, ICommand> GetButtonMappings() { return new Dictionary<Type, ICommand>(); }

        private Dictionary<MouseButton, ICommand> GetMouseMappings() { return new Dictionary<MouseButton, ICommand>(); }

        private List<Keys> GetRepeatableKeyboardKeys() { return new List<Keys>(); }

        private List<Buttons> GetRepeatableGamepadButtons() {
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
