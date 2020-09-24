using Sprint0.Link.NotMoving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link.Walking
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

        public LinkDamagedWalkingDownState(Link link, DateTime healthyDateTime)
        {
            this.link = link;
            this.healthyDateTime = healthyDateTime;
        }

        public void MoveDown()
        {
            // Already walking down, do nothing
        }

        public void MoveLeft()
        {
            link.State = new LinkDamagedWalkingLeftState(link, healthyDateTime);
        }

        public void MoveRight()
        {
            link.State = new LinkDamagedWalkingRightState(link, healthyDateTime);
        }

        public void MoveUp()
        {
            link.State = new LinkDamagedWalkingUpState(link, healthyDateTime);
        }

        public void BeDamaged()
        {
            // Already damaged, do nothing
        }

        public void BeHealthy()
        {
            link.State = new LinkWalkingDownState(link);
        }

        public void StopMoving()
        {
            link.State = new LinkDamagedStandingStillDownState(link, healthyDateTime);
        }

        public void Update()
        {
            if (DateTime.Compare(DateTime.Now, healthyDateTime) > 0) BeHealthy();
        }
    }
}
