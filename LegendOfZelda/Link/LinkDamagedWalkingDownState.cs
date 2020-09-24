using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link
{
    class LinkDamagedWalkingDownState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;


        public LinkDamagedWalkingDownState(Link link)
        {
            this.link = link;
            healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
        }

        public void MoveDown()
        {
            // Already walking down, do nothing
        }

        public void MoveLeft()
        {
            link.State = new LinkDamagedWalkingLeftState(link);
        }

        public void MoveRight()
        {
            link.State = new LinkDamagedWalkingRightState(link);
        }

        public void MoveUp()
        {
            link.State = new LinkDamagedWalkingUpState(link);
        }

        public void BeDamaged()
        {
            // Already damaged, do nothing
        }

        public void BeHealthy()
        {
            link.State = new LinkWalkingDownState(link);
        }

        public void Update()
        {
            if (DateTime.Compare(DateTime.Now, healthyDateTime) > 0) link.State = new LinkWalkingDownState(link);
        }
    }
}
