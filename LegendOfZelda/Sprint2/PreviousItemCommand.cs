using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZeldanamespace LegendOfZelda.Sprint2

{
    class PreviousItemCommand : ICommand
    {
        private Game1 myGame;
        public PreviousItemCommand(Game1 game1)
        {
            myGame = game1;
        }
        public void Execute()
        {
            myGame.sprint2.PreviousItem();
        }
    }
}
