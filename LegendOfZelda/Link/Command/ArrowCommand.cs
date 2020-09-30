using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link.Command
{
    class ArrowCommand : ICommand
    {
        private Game1 loz;
        public ArrowCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.ShootBow();
        }
    }
}
