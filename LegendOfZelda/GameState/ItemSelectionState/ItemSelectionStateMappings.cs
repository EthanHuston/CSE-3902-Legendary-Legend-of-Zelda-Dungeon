using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    internal class ItemSelectionStateMappings : IGameStateControllerMappings
    {
        public Dictionary<Keys, ICommand> KeyboardMappings { get; private set; }
        public Dictionary<MouseButton, ICommand> MouseMappings { get; private set; }
        public Dictionary<Buttons, ICommand> GamepadMappings { get; private set; }
        public Dictionary<Type, ICommand> ButtonMappings { get; private set; }
        public List<Keys> RepeatableKeyboardKeys { get; private set; }
        public List<Buttons> RepeatableGamepadButtons { get; private set; }

        public ItemSelectionStateMappings(IGameState gameState)
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
                { Buttons.DPadUp, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Up) },
                { Buttons.DPadRight, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Right) },
                { Buttons.DPadDown, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Down) },
                { Buttons.DPadLeft, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Left) }
            };
        }

        public Dictionary<Keys, ICommand> GetKeyboardMappings(IGameState gameState)
        {
            ItemSelectionGameState gameStateCast = (ItemSelectionGameState)gameState;
            return new Dictionary<Keys, ICommand>
            {
                {Keys.Tab, new ResumeGameCommand(gameState) },
                {Keys.D0, new ResumeGameCommand(gameState) },
                {Keys.W, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Up) },
                {Keys.D, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Right) },
                {Keys.S, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Down) },
                {Keys.A, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Left) },
                {Keys.I, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Up) },
                {Keys.L, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Right) },
                {Keys.K, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Down) },
                {Keys.J, new MoveSelectorCommand(gameStateCast.InventoryMenu, Constants.Direction.Left) }
            };
        }

        private Dictionary<Type, ICommand> GetButtonMappings(IGameState gameState)
        {
            ItemSelectionGameState gameStateCast = (ItemSelectionGameState)gameState;
            return new Dictionary<Type, ICommand>
            {
                {typeof(ArrowWoodInventoryButton), new ChangeSecondaryToItem(gameStateCast.InventoryMenu, Link.LinkConstants.ItemType.Rupee) },
                {typeof(BombInventoryButton), new ChangeSecondaryToItem(gameStateCast.InventoryMenu, Link.LinkConstants.ItemType.Bomb) },
                {typeof(BoomerangWoodInventoryButton), new ChangeSecondaryToItem(gameStateCast.InventoryMenu, Link.LinkConstants.ItemType.Boomerang) },
                {typeof(BowInventoryButton), new ChangeSecondaryToItem(gameStateCast.InventoryMenu, Link.LinkConstants.ItemType.Rupee) },
            };
        }

        private Dictionary<MouseButton, ICommand> GetMouseMappings() { return new Dictionary<MouseButton, ICommand>(); }

        private List<Keys> GetRepeatableKeyboardKeys() { return new List<Keys>(); }

        private List<Buttons> GetRepeatableGamepadButtons() { return new List<Buttons>(); }
    }
}
