using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Controller
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

        public MouseController(Dictionary<MouseButton, ICommand> mouseMappings, Dictionary<Type, ICommand> buttonMappings, List<IButton> buttons)
        {
            oldMouseState = new MouseState();
            this.buttons = buttons;
            this.buttonMappings = buttonMappings;
            mouseButtonMappings = mouseMappings;
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
