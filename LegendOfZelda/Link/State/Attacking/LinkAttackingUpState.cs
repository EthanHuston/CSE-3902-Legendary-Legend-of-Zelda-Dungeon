using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link.State.Attacking
{
    class LinkAttackingUpState : ILinkState
    {
        private Link link;
        public LinkAttackingUpState(Link link)
        {
            InitClass(link);
        }

        private void InitClass(Link link)
        {
            this.link = link;
            // TODO: draw sprite
        }

        public void BeDamaged(int damage)
        {
            throw new NotImplementedException();
        }

        public void BeHealthy()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void MoveDown()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void MoveUp()
        {
            throw new NotImplementedException();
        }

        public void StopMoving()
        {
            throw new NotImplementedException();
        }

        public void SwordDown()
        {
            throw new NotImplementedException();
        }

        public void SwordLeft()
        {
            throw new NotImplementedException();
        }

        public void SwordRight()
        {
            throw new NotImplementedException();
        }

        public void SwordUp()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
