using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Rooms
{
    internal class MouseController : IController
    {
        private readonly ICommand leftClickCommand;
        private readonly ICommand rightClickCommand;
        private MouseState oldMouseState;

        public MouseController(IGameState gameState)
        {
            RoomGameState gameStateCast = (RoomGameState)gameState;

            oldMouseState = new MouseState();
            leftClickCommand = new UsePrimaryItem(gameStateCast.GetPlayer(0));
            rightClickCommand = new UseSecondaryItem(gameStateCast.GetPlayer(0));
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
                leftClickCommand.Execute();


            if (newMouseState.RightButton == ButtonState.Pressed && localOldMouseState.RightButton != ButtonState.Pressed)
                rightClickCommand.Execute();

            oldMouseState = newMouseState;
        }
    }
}
