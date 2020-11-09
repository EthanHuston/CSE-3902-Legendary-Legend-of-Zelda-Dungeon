using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.GameState.GameLoseState
{
    internal class MouseController : IController
    {
        private MouseState oldMouseState;
        private readonly List<ISpawnable> buttons;
        private Dictionary<Type, ICommand> controllerMappings;

        public MouseController(IGameState gameState, List<ISpawnable> buttons)
        {
            oldMouseState = new MouseState();
            this.buttons = buttons;
            InitControllerMappings(gameState);
        }

        private void InitControllerMappings(IGameState gameState)
        {
            controllerMappings = new Dictionary<Type, ICommand>
            {
                {typeof(RetryButton), new MainMenuCommand(gameState) },
                {typeof(ExitButton), new ExitGameCommand(gameState) }
            };
        }

        public GameStateConstants.InputType GetInputType()
        {
            return GameStateConstants.InputType.Mouse;
        }

        public OldInputState GetOldInputState()
        {
            return new OldInputState { oldMouseState = oldMouseState };
        }

        public void SetOldInputState(OldInputState oldInputState)
        {
            oldMouseState = oldInputState.oldMouseState;
        }

        public void Update()
        {
            MouseState newMouseState = Mouse.GetState();
            MouseState localOldMouseState = oldMouseState;
            oldMouseState = newMouseState;

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
                        controllerMappings[button.GetType()].Execute();
                }
            }

            oldMouseState = newMouseState;
        }
    }
}
