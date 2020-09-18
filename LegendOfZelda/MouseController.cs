using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class MouseController : IController
    {
        //Mouse controller code/logic taken from rbwhitaker tutorials
        private Game1 myGame;
        private MouseState mouseState;
        private MouseState oldState;

        public MouseController(Game1 game1)
        {
            myGame = game1;
        }

        public void Update()
        {
            mouseState = Mouse.GetState();
            if(mouseState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                int x = mouseState.X;
                int y = mouseState.Y;
                if(x <= 400 && y <= 240)
                {
                    SetStillSpriteCommand setStillSpriteCommand = new SetStillSpriteCommand(myGame);
                    setStillSpriteCommand.Execute();
                } else if (x < 400 && y > 240)
                {
                    SetDeadSpriteCommand setDeadSpriteCommand = new SetDeadSpriteCommand(myGame);
                    setDeadSpriteCommand.Execute();

                } else if(x >= 400 && y <= 240)
                {
                    SetWalkingStillSpriteCommand setWalkingStillSpriteCommand = new SetWalkingStillSpriteCommand(myGame);
                    setWalkingStillSpriteCommand.Execute();
                }
                else
                {
                    SetFullWalkingSpriteCommand setFullWalkingSpriteCommand = new SetFullWalkingSpriteCommand(myGame);
                    setFullWalkingSpriteCommand.Execute();
                }

            } else if(mouseState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
            {
                QuitGameCommand quitGameCommand = new QuitGameCommand(myGame);
                quitGameCommand.Execute();
            }
            oldState = mouseState;
        }
    }
}
