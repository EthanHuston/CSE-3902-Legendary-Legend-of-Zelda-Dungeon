using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    internal class MouseController : IController
    {
        private readonly Dictionary<MouseButton, ICommand> mouseButtonMappings;
        private readonly Dictionary<Type, ICommand> buttonMappings;
        private readonly List<IButton> buttons;
        private MouseState oldMouseState;

        public InputType InputType { get; } = InputType.Keyboard;
        public InputStates OldInputState
        {
            get => new InputStates { MouseState = oldMouseState };
            set => oldMouseState = value.MouseState;
        }

        public MouseController(IGameState gameState, List<IButton> buttons)
        {
            oldMouseState = new MouseState();
            this.buttons = buttons;
            buttonMappings = GetButtonMappings(gameState);
            mouseButtonMappings = GetMouseButtonsMappings(gameState);
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

        private Dictionary<MouseButton, ICommand> GetMouseButtonsMappings(IGameState gameState)
        {
            return new Dictionary<MouseButton, ICommand>
            {
            };
        }

        public void Update()
        {
            MouseState newMouseState = Mouse.GetState();
            MouseState localOldMouseState = oldMouseState;
            oldMouseState = newMouseState;

            foreach (KeyValuePair<MouseButton, ICommand> keyValuePair in mouseButtonMappings)
            {
                if (GetMouseButtonState(newMouseState, keyValuePair.Key) == ButtonState.Pressed && localOldMouseState.LeftButton != ButtonState.Pressed)
                    keyValuePair.Value.Execute();
            }

            if (newMouseState.LeftButton == ButtonState.Pressed && localOldMouseState.LeftButton != ButtonState.Pressed)
            {
                Point mousePosition = newMouseState.Position;
                foreach (IButton button in buttons)
                {
                    Rectangle buttonRectangle = button.GetRectangle();
                    if (mousePosition.X > buttonRectangle.Left &&
                        mousePosition.X < buttonRectangle.Right &&
                        mousePosition.Y > buttonRectangle.Top &&
                        mousePosition.Y < buttonRectangle.Bottom)
                        buttonMappings[button.GetType()].Execute();
                }
            }
        }

        private ButtonState GetMouseButtonState(MouseState mouseState, MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LeftButton:
                    return mouseState.LeftButton;
                case MouseButton.RightButton:
                    return mouseState.RightButton;
                case MouseButton.MiddleButton:
                    return mouseState.MiddleButton;
                default:
                    return ButtonState.Released;
            }
        }
    }
}
