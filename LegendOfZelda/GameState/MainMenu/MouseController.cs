using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.GameState.MainMenu
{
    internal class MouseController : IController
    {
        private MouseState oldMouseState;

        public MouseController(IGameState gameState)
        {
            this.oldMouseState = new MouseState();
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
            
            // TODO: execute commands here

            oldMouseState = newMouseState;
        }
    }
}
