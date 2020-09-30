using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link.Command
{
    class WoodenBoomerangHoldCommand : ICommand
    {
        private Game1 loz;
        public WoodenBoomerangHoldCommand(Game1 game)
        {
            loz = game;
        }
        public void Execute()
        {
            loz.link.PickUpBoomerang();
        }
    }
}
