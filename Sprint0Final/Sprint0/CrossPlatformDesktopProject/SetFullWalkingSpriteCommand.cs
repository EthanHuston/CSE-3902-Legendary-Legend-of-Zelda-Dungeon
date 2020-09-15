using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class SetFullWalkingSpriteCommand : ICommand
    {
        private Game1 myGame;
        public SetFullWalkingSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.sprite = new MovingAnimatedSprite(myGame.Content);
        }
    }
}
