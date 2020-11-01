using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.GameState.MainMenu
{
    internal class MouseController : IController
    {
        private MouseState oldMouseState;

        public MouseController(IGameState gameState)
        {
            oldMouseState = new MouseState();
        }

        public void Update()
        {
            MouseState newMouseState = Mouse.GetState();
            
            // TODO: execute commands here

            oldMouseState = newMouseState;
        }
    }
}
