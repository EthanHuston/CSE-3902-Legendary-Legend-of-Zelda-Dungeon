using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class MouseController : IController
    {
        private Game1 myGame;
        private Dictionary<Constants.Direction, ICommand> leftClickCommands;

        public MouseController(Game1 game1)
        {
            myGame = game1;
            leftClickCommands = new Dictionary<Constants.Direction, ICommand>();
            
        }

        public void RegisterCommand(Constants.Direction dir, ICommand command)
        {
            leftClickCommands.Add(dir, command);
        }

        public void Update()
        {
            
        }

        private Point GetLocation()
        {
            return Mouse.GetState().Position;
        }

    }
}
