using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link
{
    class LinkWalkingLeftState : ILinkState
    {
        private Link link;

        public LinkWalkingLeftState(Link link)
        {
            this.link = link;
        }

        public void MoveDown()
        {
            link.State = new LinkWalkingDownState(link);
        }

        public void MoveLeft()
        {
            // Already walking left, do nothing
        }

        public void MoveRight()
        {
            link.State = new LinkWalkingRightState(link);
        }

        public void MoveUp()
        {
            link.State = new LinkWalkingUpState(link);
        }

        public void BeDamaged()
        {
            // link.State = new LinkDamagedWalkingLeftState(link);
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
