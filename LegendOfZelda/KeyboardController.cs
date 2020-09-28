using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class KeyboardController : IController
    {
        private Game1 myGame;
        private Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController(Game1 game1)
        {
            this.myGame = game1;
            controllerMappings = new Dictionary<Keys, ICommand>();
            this.RegisterCommand(Keys.NumPad0, new QuitGameCommand(game1));
            this.RegisterCommand(Keys.NumPad1, new SetStillSpriteCommand(game1));
            this.RegisterCommand(Keys.NumPad2, new SetWalkingStillSpriteCommand(game1));
            this.RegisterCommand(Keys.NumPad3, new SetDeadSpriteCommand(game1));
            this.RegisterCommand(Keys.NumPad4, new SetFullWalkingSpriteCommand(game1));
            this.RegisterCommand(Keys.D0, new QuitGameCommand(game1));
            this.RegisterCommand(Keys.D1, new SetStillSpriteCommand(game1));
            this.RegisterCommand(Keys.D2, new SetWalkingStillSpriteCommand(game1));
            this.RegisterCommand(Keys.D3, new SetDeadSpriteCommand(game1));
            this.RegisterCommand(Keys.D4, new SetFullWalkingSpriteCommand(game1));
            this.RegisterCommand(Keys.W, new WalkingForwardCommand(game1));
            this.RegisterCommand(Keys.Up, new WalkingForwardCommand(game1));
            this.RegisterCommand(Keys.A, new WalkingLeftCommand(game1));
            this.RegisterCommand(Keys.Left, new WalkingLeftCommand(game1));
            this.RegisterCommand(Keys.D, new WalkingRightCommand(game1));
            this.RegisterCommand(Keys.Right, new WalkingRightCommand(game1));
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
                
            }

        }
    }
}
