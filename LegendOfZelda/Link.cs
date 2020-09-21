using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Link : IPlayer
    {
        private int health;
        private ILinkState state;
        private Game1 game;

        public Link(Game1 game) {
            // health = PLAYER_HEALTH_START
            this.game = game;
            // state = someInitialStateClass
        }
    }
}
