using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Sprint2
{
    class NextBlockCommand : ICommand
    {
        private Game1 myGame;
        public NextBlockCommand(Game1 game1)
        {
            myGame = game1;
        }
        public void Execute()
        {
            myGame.sprint2.NextBlock();
        }
    }
}
