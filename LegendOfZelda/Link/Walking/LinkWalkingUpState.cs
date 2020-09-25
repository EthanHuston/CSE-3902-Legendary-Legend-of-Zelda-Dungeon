using Sprint0.Link.NotMoving;
using Sprint0.Link.Walking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link
{
    class LinkWalkingUpState : ILinkState
    {
        private Link link;

        public LinkWalkingUpState(Link link)
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
            // Already walking up, do nothing
        }

        public void BeDamaged(int damage)
        {
            link.State = new LinkDamagedWalkingUpState(link, damage);
        }

        public void BeHealthy()
        {
            // Already in health state, do nothing
        }

        public void StopMoving()
        {
            link.State = new LinkStandingStillUpState(link);
        }

        public void Update()
        {
        }
    }
}
