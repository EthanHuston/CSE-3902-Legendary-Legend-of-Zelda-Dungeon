using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Rooms
{
    internal class MouseController : IController
    {
        private readonly Dictionary<Constants.Direction, ICommand> leftClickRoomCommands;
        private readonly ICommand leftClickCommand;
        private readonly ICommand rightClickCommand;
        private MouseState oldMouseState;

        public MouseController(IGameState gameState)
        {
            RoomGameState gameStateCast = (RoomGameState)gameState;

            oldMouseState = new MouseState();
            leftClickCommand = new UsePrimaryItem(gameStateCast.GetPlayer(0));
            rightClickCommand = new UseSecondaryItem(gameStateCast.GetPlayer(0));
            leftClickRoomCommands = new Dictionary<Constants.Direction, ICommand>();
            RegisterCommand(Constants.Direction.Down, new ChangeRoomDownCommand(gameStateCast));
            RegisterCommand(Constants.Direction.Left, new ChangeRoomLeftCommand(gameStateCast));
            RegisterCommand(Constants.Direction.Right, new ChangeRoomRightCommand(gameStateCast));
            RegisterCommand(Constants.Direction.Up, new ChangeRoomUpCommand(gameStateCast));
        }

        public GameStateConstants.InputType GetInputType()
        {
            return GameStateConstants.InputType.Mouse;
        }

        public OldInputState GetOldInputState()
        {
            return new OldInputState { oldMouseState = oldMouseState };
        }

        public void RegisterCommand(Constants.Direction dir, ICommand command)
        {
            leftClickRoomCommands.Add(dir, command);
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
                Constants.Direction dir = GetDirectionFromClick(newMouseState.Position);
                if (leftClickRoomCommands.ContainsKey(dir))
                {
                    leftClickRoomCommands[dir].Execute();
                }

                leftClickCommand.Execute();
            }

            if (newMouseState.RightButton == ButtonState.Pressed && localOldMouseState.RightButton != ButtonState.Pressed)
            {
                rightClickCommand.Execute();
            }

            oldMouseState = newMouseState;
        }

        private Constants.Direction GetDirectionFromClick(Point mousePos)
        {
            if (mousePos.X > RoomConstants.TopDoorX && mousePos.X < RoomConstants.TopDoorX + RoomConstants.WallWidth)
            {
                if (mousePos.Y > RoomConstants.TopDoorY && mousePos.Y < RoomConstants.TopDoorY + RoomConstants.WallWidth)
                    return Constants.Direction.Up;
                else if (mousePos.Y > RoomConstants.BottomDoorY && mousePos.Y < RoomConstants.BottomDoorY + RoomConstants.WallWidth)
                    return Constants.Direction.Down;
            }

            else if (mousePos.Y > RoomConstants.LeftDoorY && mousePos.Y < RoomConstants.LeftDoorY + RoomConstants.WallWidth)
            {
                if (mousePos.X >= RoomConstants.LeftDoorX && mousePos.X <= RoomConstants.LeftDoorX + RoomConstants.WallWidth)
                    return Constants.Direction.Left;
                else if (mousePos.X >= RoomConstants.RightDoorX && mousePos.X <= RoomConstants.RightDoorX + RoomConstants.WallWidth)
                    return Constants.Direction.Right;
            }

            return Constants.Direction.None;
        }

    }
}
