using Sprint0.Link.Walking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Link.NotMoving
{
    class LinkDamagedStandingStillUpState : ILinkState
    {
        private Link link;
        private DateTime healthyDateTime;

        public LinkDamagedStandingStillUpState(Link link, int damage)
        {
            this.link = link;
            this.link.subtractHealth(damage);
            healthyDateTime = DateTime.Now.AddMilliseconds(Constants.LinkDamageEffectTimeMs);
        }
        public LinkDamagedStandingStillUpState(Link link, DateTime healthyDateTime)
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
            link.State = new LinkDamagedWalkingUpState(link, healthyDateTime);
        }

        public void BeDamaged(int damage)
        {
            // Already damaged, do nothing
        }

        public void BeHealthy()
        {
            link.State = new LinkStandingStillDownState(link);
        }

        public void StopMoving()
        {
            // Already not moving, do nothing
        }

        public void Update()
        {
            if (DateTime.Compare(DateTime.Now, healthyDateTime) > 0) BeHealthy();
        }
    }
}
