using Sprint0.Link.NotMoving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link
{
    class Link : IPlayer
    {
        public ILinkState State;
        private int health;
        private Game1 game;

        public Link(Game1 game)
        {
            health = Constants.LinkHealth;
            this.game = game;
            State = new LinkStandingStillDownState(this);
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Heal(int healAmount)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            State.BeDamaged(damage);
        }

        public void SubtractHealth(int damage)
        {
            health -= damage;
        }
    }
}
