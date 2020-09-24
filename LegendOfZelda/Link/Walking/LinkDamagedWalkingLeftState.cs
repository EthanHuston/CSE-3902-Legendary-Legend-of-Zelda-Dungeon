using Sprint0.Link.NotMoving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link.Walking
{
    class LinkDamagedWalkingLeftState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;


        public LinkDamagedWalkingLeftState(Link link)
        {
            this.link = link;
            healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
        }

        public LinkDamagedWalkingLeftState(Link link, DateTime healthyDateTime)
        {
            this.link = link;
            this.healthyDateTime = healthyDateTime;
        }

        public void MoveDown()
        {
            link.State = new LinkDamagedWalkingDownState(link, healthyDateTime);
        }

        public void MoveLeft()
        {
            // Already walking left, do nothing
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
            link.State = new LinkWalkingLeftState(link);
        }

        public void StopMoving()
        {
            link.State = new LinkDamagedStandingStillLeftState(link, healthyDateTime);
        }

        public void Update()
        {
            if (DateTime.Compare(DateTime.Now, healthyDateTime) > 0) BeHealthy();
        }
    }
}
