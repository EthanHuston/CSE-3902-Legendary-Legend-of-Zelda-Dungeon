using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState
{
    static class GameStateConstants
    {
        private const double gameScaler = Constants.GameScaler;

        // Button Positions
        public static Point PauseStateResumeButtonLocation => new Point((int)(gameScaler * 48), (int)(gameScaler * 64));
        public static Point PauseStateExitButtonLocation => new Point((int)(gameScaler * 96), (int)(gameScaler * 96));
        public static Point PauseStateMainMenuButtonLocation => new Point((int)(gameScaler * 144), (int)(gameScaler * 64));

        public enum InputType
        {
            Keyboard,
            Mouse,
            Gamepad
        }

        public static OldInputState GetOldInputState(List<IController> controllerList)
        {
            OldInputState oldInputState = new OldInputState();

            foreach (IController controller in controllerList)
            {
                switch (controller.GetInputType())
                {
                    case InputType.Keyboard:
                        oldInputState.oldKeyboardState = controller.GetOldInputState().oldKeyboardState;
                        break;

                    case InputType.Mouse:
                        oldInputState.oldMouseState = controller.GetOldInputState().oldMouseState;
                        break;
                }
            }

            return oldInputState;
        }
    }
}
