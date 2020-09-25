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
            State.Draw();
        }

        public void Update()
        {
            State.Update();
        }

        public void Heal(int healAmount)
        {
            State.BeHealthy();
            health += healAmount;
        }

        public void TakeDamage(int damage)
        {
            State.BeDamaged(damage);
        }

        public void SubtractHealth(int damage)
        {
            health -= damage;
        }

        public void MoveUp()
        {
            State.MoveUp();
        }

        public void MoveDown()
        {
            State.MoveDown();
        }
        public void MoveLeft()
        {
            State.MoveLeft();
        }
        public void MoveRight()
        {
            State.MoveRight();
        }

        public void StopMoving()
        {
            State.StopMoving();
        }
    }
}
