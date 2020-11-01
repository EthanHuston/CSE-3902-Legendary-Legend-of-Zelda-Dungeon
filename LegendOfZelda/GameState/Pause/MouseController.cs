using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.GameState.Pause
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
            
            // TODO: add commands here

            oldMouseState = newMouseState;
        }
    }
}
