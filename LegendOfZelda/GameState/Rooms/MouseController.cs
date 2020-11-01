using LegendOfZelda.GameState;
using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameState.Rooms
{
    internal class MouseController : IController
    {
        private readonly Dictionary<Constants.Direction, ICommand> leftClickCommands;
        private MouseState oldMouseState;

        public MouseController(IGameState gameState)
        {
            RoomGameState gameStateCast = (RoomGameState)gameState;

            oldMouseState = new MouseState();
            leftClickCommands = new Dictionary<Constants.Direction, ICommand>();
            RegisterCommand(Constants.Direction.Down, new ChangeRoomDownCommand(gameStateCast));
            RegisterCommand(Constants.Direction.Left, new ChangeRoomLeftCommand(gameStateCast));
            RegisterCommand(Constants.Direction.Right, new ChangeRoomRightCommand(gameStateCast));
            RegisterCommand(Constants.Direction.Up, new ChangeRoomUpCommand(gameStateCast));
        }

        public void RegisterCommand(Constants.Direction dir, ICommand command)
        {
            leftClickCommands.Add(dir, command);
        }

        public void Update()
        {
            MouseState newMouseState = Mouse.GetState();
            if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton != ButtonState.Pressed)
            {
                Constants.Direction dir = GetDirectionFromClick(newMouseState.Position);
                if (leftClickCommands.ContainsKey(dir))
                    leftClickCommands[dir].Execute();
            }
            oldMouseState = newMouseState;
        }

        private Constants.Direction GetDirectionFromClick(Point mousePos)
        {
            if (mousePos.X > RoomConstants.topDoorX && mousePos.X < RoomConstants.topDoorX + RoomConstants.wallWidth)
            {
                if (mousePos.Y > RoomConstants.topDoorY && mousePos.Y < RoomConstants.topDoorY + RoomConstants.wallWidth)
                    return Constants.Direction.Up;
                else if (mousePos.Y > RoomConstants.bottomDoorY && mousePos.Y < RoomConstants.bottomDoorY + RoomConstants.wallWidth)
                    return Constants.Direction.Down;
            }

            else if (mousePos.Y > RoomConstants.leftDoorY && mousePos.Y < RoomConstants.leftDoorY + RoomConstants.wallWidth)
            {
                if (mousePos.X >= RoomConstants.leftDoorX && mousePos.X <= RoomConstants.leftDoorX + RoomConstants.wallWidth)
                    return Constants.Direction.Left;
                else if (mousePos.X >= RoomConstants.rightDoorX && mousePos.X <= RoomConstants.rightDoorX + RoomConstants.wallWidth)
                    return Constants.Direction.Right;
            }

            return Constants.Direction.None;
        }

    }
}
