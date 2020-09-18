using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class SetStillSpriteCommand : ICommand
    {
        private Game1 myGame;
        public SetStillSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.sprite = new NonMovingNonAnimatedSprite(myGame.Content);
        }
    }
}
