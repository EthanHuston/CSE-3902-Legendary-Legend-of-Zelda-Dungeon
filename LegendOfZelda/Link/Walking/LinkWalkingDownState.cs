using Sprint0.Link.NotMoving;
using Sprint0.Link.Walking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link
{
    class LinkWalkingDownState : ILinkState
    {
        private Link link;

        public LinkWalkingDownState(Link link)
        {
            this.link = link;
        }

        public void MoveDown()
        {
            // Already walking down, do nothing
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
            link.State = new LinkDamagedWalkingDownState(link, damage);
        }

        public void BeHealthy()
        {
            // Already in healthy state, do nothing
        }

        public void StopMoving()
        {
            link.State = new LinkStandingStillDownState(link);
        }

        public void Update()
        {
        }
    }
}
