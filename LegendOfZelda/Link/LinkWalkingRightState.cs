using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link
{
    class LinkWalkingRightState : ILinkState
    {
        private Link link;

        public LinkWalkingRightState(Link link)
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
            // Already walking right, do nothing
        }

        public void MoveUp()
        {
            link.State = new LinkWalkingUpState(link);
        }

        public void BeDamaged()
        {
            // link.State = new LinkDamagedWalkingRightState(link);
        }

        public void BeHealthy()
        {
            // Already in healthy state, do nothing
        }

        public void Update()
        {
        }
    }
}
