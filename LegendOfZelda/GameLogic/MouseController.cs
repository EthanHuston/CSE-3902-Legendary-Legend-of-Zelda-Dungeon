using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using LegendOfZelda.Rooms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda.GameLogic
{
    public class MouseController : IController
    {
        private Game1 myGame;
        private Dictionary<Constants.Direction, ICommand> leftClickCommands;
        private MouseState oldMouseState;

        public MouseController(Game1 game1)
        {
            myGame = game1;
            oldMouseState = new MouseState();
            leftClickCommands = new Dictionary<Constants.Direction, ICommand>();
            RegisterCommand(Constants.Direction.Down, new ChangeRoomDownCommand(((RoomGameState)myGame.State).RoomManager));
            RegisterCommand(Constants.Direction.Left, new ChangeRoomLeftCommand(((RoomGameState)myGame.State).RoomManager));
            RegisterCommand(Constants.Direction.Right, new ChangeRoomRightCommand(((RoomGameState)myGame.State).RoomManager));
            RegisterCommand(Constants.Direction.Up, new ChangeRoomUpCommand(((RoomGameState)myGame.State).RoomManager));
        }

        public void RegisterCommand(Constants.Direction dir, ICommand command)
        {
            leftClickCommands.Add(dir, command);
        }

        public void Update()
        {
            MouseState newMouseState = Mouse.GetState();
            if(newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton != ButtonState.Pressed)
            {
                Constants.Direction dir = GetDirectionFromClick(newMouseState.Position);
                if (leftClickCommands.ContainsKey(dir))
                    leftClickCommands[dir].Execute();
            }
            oldMouseState = newMouseState;
        }

        private Point GetLocation()
        {
            return Mouse.GetState().Position;
        }

        private Constants.Direction GetDirectionFromClick(Point mousePos)
        {
            Constants.Direction dir = Constants.Direction.Down;
            
            if (mousePos.X > RoomConstants.topDoorX && mousePos.X < RoomConstants.topDoorX + RoomConstants.wallWidth)
            {
                if (mousePos.Y > RoomConstants.topDoorY && mousePos.Y < RoomConstants.topDoorY + RoomConstants.wallWidth)
                    dir = Constants.Direction.Up;
                else if (mousePos.Y > RoomConstants.bottomDoorY && mousePos.Y < RoomConstants.bottomDoorY + RoomConstants.wallWidth)
                    dir = Constants.Direction.Down;
            }

            else if (mousePos.Y > RoomConstants.leftDoorY && mousePos.Y < RoomConstants.leftDoorY + RoomConstants.wallWidth)
            {
                if (mousePos.X >= RoomConstants.leftDoorX && mousePos.X <= RoomConstants.leftDoorX + RoomConstants.wallWidth)
                    dir = Constants.Direction.Left;
                else if (mousePos.X >= RoomConstants.rightDoorX && mousePos.X <= RoomConstants.rightDoorX + RoomConstants.wallWidth)
                    dir = Constants.Direction.Right;
            }

            return dir;
        }

    }
}
