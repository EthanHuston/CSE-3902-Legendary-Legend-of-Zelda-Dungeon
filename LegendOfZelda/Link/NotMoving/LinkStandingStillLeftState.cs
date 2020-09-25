using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link.NotMoving
{
    class LinkStandingStilLeftState : ILinkState
    {
        private Link link;

        public LinkStandingStilLeftState(Link link)
        {
            this.link = link;
        }

        public void MoveDown()
        {
            link.State = new LinkWalkingDownState(link);
        }

        public void MoveLeft()
        {
            link.State = new LinkWalkingLeftState(link);
        }

        public void MoveRight()
        {
            link.State = new LinkWalkingRightState(link);
        }

        public void MoveUp()
        {
            link.State = new LinkWalkingUpState(link);
        }

        public void BeDamaged(int damage)
        {
            link.State = new LinkDamagedStandingStillLeftState(link, damage);
        }

        public void BeHealthy()
        {
            // Already in healthy state, do nothing
        }

        public void StopMoving()
        {
            // Already not moving, do nothing
        }

        public void Update()
        {
        }
    }
}
