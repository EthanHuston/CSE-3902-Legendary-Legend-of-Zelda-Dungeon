using LegendOfZelda.GameState.Utilities;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using LegendOfZelda.Link.Interface;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.RoomsState
{
    internal class MouseController : IController
    {
        private readonly Dictionary<MouseButton, ICommand> mouseButtonMappings;
        private readonly Dictionary<Type, ICommand> buttonMappings;
        private readonly List<IButton> buttons;
        private MouseState oldMouseState;

        public InputType InputType { get; } = InputType.Mouse;
        public InputStates OldInputState
        {
            get => new InputStates { MouseState = oldMouseState };
            set => oldMouseState = value.MouseState;
        }

        public MouseController(IGameState gameState, List<IButton> buttons)
        {
            RoomGameState gameStateCast = (RoomGameState)gameState;

            // temporary until we pass in pre-made command dictionary
            IPlayer player = gameStateCast.GetPlayer(0);
            // end temp

            oldMouseState = new MouseState();
            this.buttons = buttons;
            buttonMappings = GetButtonMappings(gameState);
            mouseButtonMappings = GetMouseButtonsMappings(player);
        }

        private Dictionary<Type, ICommand> GetButtonMappings(IGameState gameState)
        {
            return new Dictionary<Type, ICommand>
            {
            };
        }

        private Dictionary<MouseButton, ICommand> GetMouseButtonsMappings(IPlayer player)
        {
            return new Dictionary<MouseButton, ICommand>
            {
                {MouseButton.LeftButton, new UsePrimaryItemCommand(player) },
                {MouseButton.RightButton, new UseSecondaryItemCommand(player) }
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
                foreach (ISpawnable button in buttons)
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
