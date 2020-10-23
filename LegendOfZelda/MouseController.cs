using LegendOfZelda.Interface;
using LegendOfZelda.Link.Command;
using LegendOfZelda.Sprint2;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class MouseController : IController
    {
        private Game1 myGame;
        private Dictionary<Keys, ICommand> controllerMappings;

        public MouseController(Game1 game1)
        {
            myGame = game1;
            controllerMappings = new Dictionary<Keys, ICommand>();
            
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            
        }

    }
}
