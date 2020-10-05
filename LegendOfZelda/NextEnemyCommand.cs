using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class NextEnemyCommand : ICommand
    {
        private Game1 myGame;
        public NextEnemyCommand(Game1 game1)
        {
            myGame = game1;
        }
        public void Execute()
        {
            myGame.sprint2.NextEnemy();
        }
    }
}
