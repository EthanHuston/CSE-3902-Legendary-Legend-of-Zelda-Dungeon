using LegendOfZelda.GameState.Command;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.GameState.MainMenu
{
    internal class MouseController : IController
    {
        private MouseState oldMouseState;
        private readonly ICommand startGameCommand;

        public MouseController(IGameState gameState)
        {
            oldMouseState = new MouseState();
            startGameCommand = new StartGameCommand(gameState);
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

            if (newMouseState.LeftButton == ButtonState.Pressed && localOldMouseState.LeftButton != ButtonState.Pressed) startGameCommand.Execute();

            oldMouseState = newMouseState;
        }
    }
}
