using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    
    class SetDeadSpriteCommand : ICommand
    {
        private Game1 myGame;
        public SetDeadSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.sprite = new MovingNonAnimatedSprite(myGame.Content);
        }

    }
}
