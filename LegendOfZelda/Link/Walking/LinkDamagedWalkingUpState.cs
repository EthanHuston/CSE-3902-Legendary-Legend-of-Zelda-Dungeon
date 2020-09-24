using Sprint0.Link.NotMoving;
using Sprint0.Link.Walking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link.Walking
{
    class LinkDamagedWalkingUpState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;

        public LinkDamagedWalkingUpState(Link link)
        {
            this.link = link;
            healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
        }

        public LinkDamagedWalkingUpState(Link link, DateTime healthyDateTime)
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
            link.State = new LinkDamagedWalkingLeftState(link, healthyDateTime);
        }

        public void MoveRight()
        {
            link.State = new LinkDamagedWalkingRightState(link, healthyDateTime);
        }

        public void MoveUp()
        {
            // Already walking up, do nothing
        }

        public void BeDamaged()
        {
            // Already damaged, do nothing           
        }

        public void BeHealthy()
        {
            link.State = new LinkWalkingUpState(link);
        }

        public void StopMoving()
        {
            link.State = new LinkDamagedStandingStillUpState(link, healthyDateTime);
        }

        public void Update()
        {
            if (DateTime.Compare(DateTime.Now, healthyDateTime) > 0) BeHealthy();
        }
    }
}
